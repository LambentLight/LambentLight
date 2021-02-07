from setuptools import setup, find_packages


with open("requirements.txt") as file:
    requirements = file.readlines()


setup(
    name="lambentlight.client",
    version="3.0",
    packages=find_packages(),
    install_requires=requirements,
    author="justalemon",
    author_email="justlemoncl@gmail.com",
    description="CLI Client for connecting to the LambentLight Server.",
    keywords="fivem redm cfx manager",
    url="https://github.com/LambentLight/LambentLight",
    project_urls={
        "Bug Tracker": "https://github.com/LambentLight/LambentLight/issues",
        "Documentation": "https://justalemon.ml/LambentLight",
        "Source Code": "https://github.com/LambentLight/LambentLight"
    },
    classifiers=[
        "Development Status :: 5 - Production/Stable",
        "Environment :: Console",
        "Intended Audience :: Developers",
        "Intended Audience :: Other Audience",
        "Intended Audience :: System Administrators",
        "License :: OSI Approved :: MIT License",
        "Natural Language :: English",
        "Operating System :: Microsoft",
        "Operating System :: Microsoft :: Windows",
        "Operating System :: Microsoft :: Windows :: Windows 10",
        "Operating System :: POSIX :: Linux",
        "Programming Language :: Python",
        "Programming Language :: Python :: 3",
        "Programming Language :: Python :: 3.7",
        "Programming Language :: Python :: 3.8"
    ],
    entry_points={
        "console_scripts": [
            "lambentlight = lambentlight.client.__main__:main"
        ]
    }
)
