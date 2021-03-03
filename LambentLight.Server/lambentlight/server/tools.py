import errno
import os
import shutil
import stat


def __shutil_fix(func, path, exc):
    """
    Simple permission fix for read only files.
    """
    # If the function is rmdir, remove or unlink and is an access error
    if func in (os.rmdir, os.remove, os.unlink) and exc[1].errno == errno.EACCES:
        # Set 777 as the permissions and call the function again
        os.chmod(path, stat.S_IRWXU | stat.S_IRWXG | stat.S_IRWXO)
        func(path)
    # Otherwise, just raise the exception again
    else:
        raise


def rmtree(path, ignore_errors=False):
    """
    Alternative version of rmtree with support for removing read only files.
    """
    shutil.rmtree(path, ignore_errors, __shutil_fix)
