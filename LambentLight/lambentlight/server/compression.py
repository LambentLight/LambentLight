import os
import zipfile
from enum import Enum

import aiofiles
import py7zr as py7zr


class CompressionType(Enum):
    UNKNOWN = -1,
    ZIP = 0,
    SEVENZIP = 1


async def detect(path):
    """
    Detects the compression type of a file based on the header.
    """
    # Open the file for asynchronous reading as binary
    async with aiofiles.open(path, "rb") as file:
        # Check if the different files have the header, in order:
        # ZIP (PK..)
        if await file.read(4) == b"\x50\x4B\x03\x04":
            return CompressionType.ZIP
        # 7ZIP (7z¼¯'.)
        await file.seek(0)
        if await file.read(6) == b"\x37\x7A\xBC\xAF\x27\x1C":
            return CompressionType.SEVENZIP
        # If we got here, is not a known format so mark it as unknown
        return CompressionType.UNKNOWN


async def extract(path, destination):
    """
    Extracts a compressed file based on the type.
    """
    # Create the destination path if is not present
    os.makedirs(destination, exist_ok=True)
    # Get the type of compressed file
    file_type = await detect(path)

    # If we have a ZIP File, use the builtin zipfile module
    if file_type == CompressionType.ZIP:
        with zipfile.ZipFile(path) as zipf:
            zipf.extractall(destination)
            return True
    # If we have a 7Z File, use py7zr
    elif file_type == CompressionType.SEVENZIP:
        with py7zr.SevenZipFile as sevenzip:
            sevenzip.extractall(destination)
            return True
    # If we got here, the file is not a supported format
    return False
