# LambentLight Development Tools

The LambentLight Development Tools are a collection of Python Scripts for creating and managing the Metadata folders/repos.

## Installing Python 3.7+

To use the LambentLight Development Tools, you need to install Python 3.7 or higher.

!!! danger
    Python 3.8 crashes when used in combination with the scripts, don't use that set of versions.

* Go to the [Python Releases Website](https://www.python.org/downloads/)
* Scroll down until you see `Looking for a specific release?`
* Select the latest version that starts with `3.7` (right now is `3.7.6`)
* Scroll down until you see `Files`, and click on `Windows x86-64 executable installer` to download it
* Open the file and follow the instructions to install Python

## Installing the Tools

To install the LambentLight Development Tools, you just need to run the following line:

```
python -m pip install -U https://github.com/LambentLight/Metadata/archive/master.zip#egg=lambentlight
```

After that, you can check if the scripts installed correctly by running:

```
python -m lambentlight info
```
