import base64

originalString = "Hello World!"
print "Original string: " + originalString

encodedString = base64.b64encode(originalString)
print "Encoded string: " + encodedString

decodedString = base64.b64decode(encodedString)
print "Decoded string: " + decodedString
