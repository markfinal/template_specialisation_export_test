#!/bin/bash

nm -gU build/tempspecexport/Debug/libDynamicLibraryWithExports.1.dylib
objdump -exports-trie build/tempspecexport/Debug/libDynamicLibraryWithExports.1.dylib
