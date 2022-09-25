from ursina import *
from ursina.prefabs.first_person_controller import FirstPersonController

#Creating the app, adding player and adding sky
app = Ursina()
player = FirstPersonController()
Sky()

#List for all blocks
boxes = []

#Random color function
def random_color():
    red = random.Random().random() * 255
    green = random.Random().random() * 255
    blue = random.Random().random() * 255
    return color.rgb(red, green, blue)

#Add box to given position
def add_box(pos):
    boxes.append(
        Button(
            parent = scene,
            model = 'cube',
            origin=0.5,
            color=random_color(),
            position = pos,
            texture='grass'
        )
    )

#Generate the surface
for x in range(20):
    for y in range(20):
        add_box((x,0,y))
        
#Set and destroy blocks
def input(key):
    for box in boxes:
        if box.hovered:
            if key == "left mouse down":
                add_box(box.position + mouse.normal)
            if key == "right mouse down":
                boxes.remove(box)
                destroy(box)
        
#Start the app
app.run()