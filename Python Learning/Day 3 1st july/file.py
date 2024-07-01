
# File handling in python
# Python provides basic functions and methods necessary to manipulate files by default.
# You can do most of the file manipulation using a file object.
# Open a file
# Close a file
# Read or write a file
# Open a file
# Python has a built-in function open() to open a file.
# This function returns a file object, also called a handle, as it is used to read or modify the file accordingly.
# Syntax:
# file object = open(file_name [, access_mode][, buffering])
# Here are parameter details:
# file_name: The file_name argument is a string value that contains the name of the file that you want to access.
# access_mode: The access_mode determines the mode in which the file has to be opened, i.e., read, write, append, etc.
# A complete list of possible values is given below in the table. This is optional parameter and the default file access mode is read (r).
# buffering: If the buffering value is set to 0, no buffering takes place. If the buffering value is 1, line buffering is performed while accessing a file. If you specify the buffering value as an integer greater than 1, then buffering action is performed with the indicated buffer size. If negative, the buffer size is the system default(default behavior).

# Here is a list of the different modes of opening a file:
# Mode	Description
# r	Opens a file for reading. (default)
# w	Opens a file for writing. Creates a new file if it does not exist or truncates the file if it exists.
# x	Opens a file for exclusive creation. If the file already exists, the operation fails.
# a	Opens a file for appending at the end of the file without truncating it. Creates a new file if it does not exist.
# t	Opens in text mode. (default)
# b	Opens in binary mode.
# +	Opens a file for updating (reading and writing)

# Example of opening a file
# f = open("test.txt")    # open file in current directory
# f = open("C:/Python38/README.txt")  # specifying full path
# f = open("test.txt", mode='r') # open file in current directory
# f = open("test.txt", mode='w') # open file in write mode
# f = open("test.txt", mode='r+') # open file in read and write mode
# f = open("test.txt", mode='a') # open file in append mode
# f = open("test.txt", mode='x') # open file for exclusive creation
# f = open("test.txt", mode='t') # open file in text mode
# f = open("test.txt", mode='b') # open file in binary mode
# f = open("test.txt", mode='rb') # open file in binary mode
# f = open("test.txt", mode='wb') # open file in write mode

# Close a file
# When you are done with operations to the file, you need to properly close the file.
# Closing a file will free up the resources that were tied with the file and is done using the close() method.
# Python has a garbage collector to clean up unreferenced objects but we must not rely on it to close the file.
# Syntax:
# file_object.close()

# Example of closing a file
# f = open("test.txt", mode='r')
# f.close()

# Read or write a file
# The file object provides a set of access methods to make our lives easier.
# We would see how to use read() and write() methods to read and write files.
# Read a file
# The read() method reads the entire file.
# You can read a file using the read(size) method. This reads at most size number of bytes from the file. If the size parameter is not specified, it reads and returns up to the end of the file.
# Example of reading a file
# f = open("test.txt", mode='r')
# f.read(4) # read the first 4 data
# f.read(4) # read the next 4 data
# f.read() # read in the rest till end of file
# f.read() # further reading returns empty sting
# f.close()

# Write to a file
# The write() method writes any string to an open file. It is important to note that Python strings can have binary data and not just text.
# The write() method does not add a newline character ('\n') to the end of the string.
# Example of writing to a file
# f = open("test.txt", mode='w')
# f.write("This is a test")
# f.close()

# Append to a file
# The append() method appends any string to the opening file.
# Example of appending to a file
# f = open("test.txt", mode='a')
# f.write("This is a test")
# f.close()


# A common way to work with files in Python is to use the with statement. This creates a temporary variable (often called f), which is only accessible in the indented block of the with statement.
# The file is automatically closed at the end of the with statement, even if exceptions occur within it.
# Syntax:
# with open("test.txt") as f:
#     # perform file operations
# Example of using with statement
# with open("test.txt", mode='r') as f:
#     f.read()

# File Methods
# There are various methods available with the file object. Some of them have been used in the above examples.
# Here is the complete list of methods in text mode with a brief description:
# Method	Description
# close()	Closes an opened file. It has no effect if the file is already closed.
# detach()	Separates the underlying binary buffer from the TextIOBase and returns it.
# fileno()	Returns an integer number (file descriptor) of the file.
# flush()	Flushes the write buffer of the file stream.
# isatty()	Returns True if the file stream is interactive.
# read(n)	Reads at most n characters from the file. Reads till end of file if it is negative or None.
# readable()	Returns True if the file stream can be read from.
# readline(n=-1)	Reads and returns one line from the file. Reads in at most n bytes if specified.
# readlines(n=-1)	Reads and returns a list of lines from the file. Reads in at most n bytes/characters if specified.
# seek(offset,from=SEEK_SET)	Changes the file position to offset bytes, in reference to from (start, current, end).
# seekable()	Returns True if the file stream supports random access.
# tell()	Returns the current file location.
# truncate(size=None)	Resizes the file stream to size bytes. If size is not specified, resizes to current location.
# writable()	Returns True if the file stream can be written to.
# write(s)	Writes the string s to the file and returns the number of characters written.
# writelines(lines)	Writes a list of lines to the file.


# A complete example of file handling

# Write to a file
try:
    with open("test.txt", mode='w') as f:
        f.write("This is a test")
except:
    print("Error in writing to file")
finally:
    print("This block will always be executed")

# Read a file
try:
    with open("test.txt", mode='r') as f:
        print(f.read())
except:
    print("Error in reading from file")
finally:
    print("This block will always be executed")
    
# Append to a file with new line
try:
    with open("test.txt", mode='a+') as f:
        f.write("\nThis is a test appended")
except:
    print("Error in appending to file")
finally:
    print("This block will always be executed")

