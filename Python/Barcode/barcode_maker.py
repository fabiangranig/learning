# importing EAN13 from the python-barcode module
from barcode import EAN13

# 12 digit number
number = "467897654324"

# pass the variable into an class
my_code = EAN13(number)

# save it
my_code.save("barcode1")
