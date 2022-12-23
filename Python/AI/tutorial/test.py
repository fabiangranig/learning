# import enviroment
import gym
from gym.envs import box2d
env = gym.make("LunarLander-v2", render_mode="humen")
env.action_space.seed(42)

observation, info = env.reset(seed=42)

for _ in range(1000):
    observation, reward, terminated, truncated, info = env.step(env.action_space.sample())

    if terminated or truncated:
        observation, info = env.reset()

env.close()