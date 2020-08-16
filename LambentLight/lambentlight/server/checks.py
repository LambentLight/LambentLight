import platform

import distro


is_windows = platform.system() == "Windows"
is_ubuntu = distro.id() == "ubuntu"
is_valid = is_windows or is_ubuntu
