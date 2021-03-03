from typing import Any, List


def __print(*data: List[List[Any]]):
    """
    Prints a list of dict.
    """
    # Create a place to store the count of tabs that we need
    length = {}
    # Start by checking the individual lists
    for i in range(len(data)):
        # Then, check the data in the list
        listfound = data[i]
        for s in range(len(data[i])):
            # Get the number of tabs for this item
            size = len(str(listfound[s]))
            # If is no size or is lower than the current one, save it
            if s not in length or length[s] < size:
                length[s] = size

    # Now, is time to print the info
    # Create a place to check if we printed the header
    header = False
    # Then, iterate the list of data
    for lst in data:
        # And then the items in the list
        for i in range(len(lst)):
            value = lst[i]
            # Get the number of tabs that we need to print
            rowsize = length[i] - len(str(value))
            # Then, go ahead and print the text and the tabs
            print(value, end=" ")
            for _ in range(rowsize):
                print(" ", end="")
        # After finishing with the list, print a new line
        print()
        # If the header has not been printed, add the line under the current item
        if not header:
            for _, number in length.items():
                print("=" * number, end="=")
            print()
            header = True


def print_as_table(data: dict, *, capitalize: bool = False):
    """
    Prints the data of a dictionary as a simple table.
    """
    # Get the largest key
    size = 0
    for key in data.keys():
        if len(key) > size:
            size = len(key)

    # Now, time to start printing
    for key, value in data.items():
        key = str(key)
        value = str(value)

        if capitalize:
            key = key[0].upper() + key[1:]

        print(key + ":" + (" " * (size - len(key) + 3)) + " " + value)


def print_with_header(header: List, *data: List[List[Any]]):
    """
    Prints the data with a header.
    """
    __print(header, *data)
