#Import the library
import qrcode

#Generate the QR code
img = qrcode.make('fabiangranig.at')

#Save the image
img.save("Fabian_Website.png")
