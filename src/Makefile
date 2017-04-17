#/**************************************************************
# * Team:      Disassembler
# *
# * Authors:   Vojtěch Hertl <xhertl04@stud.fit.vutbr.cz>
# *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
# *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
# *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
# **************************************************************/

# Windows dependencies
# GNU make for Windows http://gnuwin32.sourceforge.net/packages/make.htm
# GNU zip for Windows http://gnuwin32.sourceforge.net/packages/zip.htm
# Doxygen for Windows http://www.stack.nl/~dimitri/doxygen/download.html

ROOT_DIR=$(shell cd)\..

PROJ_DIR=Calculator
PROJ=$(PROJ_DIR)\bin\Release\$(PROJ_DIR).exe

VISUAL_STUIDO_PATH=C:\Programs\Microsoft Visual Studio\2017\Enterprise

MSTEST=Common7\IDE\MSTEST.exe
TESTS_DIR=Tests
TESTS_CONTAINER=$(ROOT_DIR)\src\$(TESTS_DIR)\bin\Debug\$(TESTS_DIR).dll
TESTS_RESULT_FILE=$(ROOT_DIR)\TestResults\Result_file

PACK_NAME=xharmi00_xhalas10_xhavla06_xhertl04
PACK_ARCHIVE=$(ROOT_DIR)\$(PACK_NAME).zip
PACK_DIR=$(ROOT_DIR)\..\$(PACK_NAME)
PACK_DOC_DIR=$(PACK_DIR)\doc
PACK_INSTALL_DIR=$(PACK_DIR)\install
PACK_REPO_DIR=$(PACK_DIR)\repo

DOC_OUTPUT_DIR=$(ROOT_DIR)\src\doxygen_output\html

.PHONY: all pack clean test doc run

# build Release project
all: $(PROJ)

$(PROJ):
# TODO: build Release project

# pack project
pack: doc
	if exist "$(PACK_DIR)" rmdir "$(PACK_DIR)" /s /q
	mkdir "$(PACK_DIR)"

	mkdir "$(PACK_DOC_DIR)"
	xcopy /s "$(DOC_OUTPUT_DIR)" "$(PACK_DOC_DIR)"

	mkdir "$(PACK_INSTALL_DIR)"
# TODO: copy installer

	mkdir "$(PACK_REPO_DIR)"
	make clean
	xcopy /s "$(ROOT_DIR)" "$(PACK_REPO_DIR)"
	mkdir "$(PACK_REPO_DIR)\.git"
	xcopy /s "$(ROOT_DIR)\.git\*" "$(PACK_REPO_DIR)\.git"

	cd "$(PACK_DIR)\.." & zip -r "$(PACK_ARCHIVE)" $(PACK_NAME)
	rmdir "$(PACK_DIR)" /s /q

# clean all temp files
clean:
# TODO

# run tests of math library
test:
# TODO: build tests
	if exist "$(TESTS_RESULT_FILE)" del "$(TESTS_RESULT_FILE)"
	cd "$(VISUAL_STUIDO_PATH)" & $(MSTEST) /testcontainer:"$(TESTS_CONTAINER)" /resultsfile:"$(TESTS_RESULT_FILE)"

# generate program documentation
doc: Doxyfile
	doxygen $<

# run program
run: $(PROJ)
	$<
