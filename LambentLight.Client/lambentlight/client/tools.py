import math
from typing import List


def print_list(*data: List[List[str]]):
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
