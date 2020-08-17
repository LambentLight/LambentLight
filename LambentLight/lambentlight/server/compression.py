import io
import os
import zipfile
from enum import Enum


class CompressionType(Enum):
    UNKNOWN = -1,
    ZIP = 0,
    SEVENZIP = 1


def detect(path):
    """
    Detects the compression type of a file based on the header.
    """
    with open(path, "rb") as file:
        if zipfile.is_zipfile(file):
            return CompressionType.ZIP
        elif is_7zip(file):
            return CompressionType.SEVENZIP
        else:
            return CompressionType.UNKNOWN


def extract(path, destination):
    """
    Extracts a compressed file based on the type.
    """
    # Create the destination path if is not present
    os.makedirs(destination, exist_ok=True)
    # Get the type of compressed file
    file_type = detect(path)
    # If is a ZIP File, use the builtin zipfile module
    if file_type == CompressionType.ZIP:
        with zipfile.ZipFile(path) as zip:
            zip.extractall(destination)
            return True


def is_7zip(file: io.BufferedReader):
    """
    Checks if a file is 7-Zip (37 7A BC AF 27 1C).
    """
    file.seek(0)
    return file.read(6) == b"\x37\x7A\xBC\xAF\x27\x1C"
