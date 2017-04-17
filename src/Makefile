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
VISUAL_STUIDO_PATH=C:\Programs\Microsoft Visual Studio\2017\Enterprise
NUGET=MSBuild\ReadyRoll\OctoPack\tools\NuGet.exe
PACKAGES_FILE=packages.config
PACKAGES_DIR=$(ROOT_DIR)\packages

PROJ_NAME=Calculator
PROJ_DIR=$(ROOT_DIR)\src\Calculator
PROJ=$(PROJ_DIR)\bin\Release\$(PROJ_NAME).exe
MSBUILD=MSBuild\15.0\Bin\MSBuild.exe
PROJ_FILE=$(PROJ_DIR)\$(PROJ_NAME).csproj

MSTEST=Common7\IDE\MSTEST.exe
TESTS_NAME=Tests
TESTS_DIR=$(ROOT_DIR)\src\Tests
TESTS_CONTAINER=$(ROOT_DIR)\src\$(TESTS_NAME)\bin\Debug\$(TESTS_NAME).dll
TEST_RESULT_DIR=$(ROOT_DIR)\TestResults
TESTS_RESULT_FILE=$(TEST_RESULT_DIR)\Result_file
TESTS_FILE=$(TESTS_DIR)\$(TESTS_NAME).csproj

PACK_NAME=xharmi00_xhalas10_xhavla06_xhertl04
PACK_ARCHIVE=$(ROOT_DIR)\$(PACK_NAME).zip
PACK_DIR=$(ROOT_DIR)\..\$(PACK_NAME)
PACK_DOC_DIR=$(PACK_DIR)\doc
PACK_INSTALL_DIR=$(PACK_DIR)\install
PACK_REPO_DIR=$(PACK_DIR)\repo

DOC_OUTPUT_DIR=$(ROOT_DIR)\src\doxygen_output

STANDARD_DEVIATION_DIR=StandardDeviation

.PHONY: all build pack clean test build_test nuget_test doc run

# build Release project
all: build

build:
	cd "$(VISUAL_STUIDO_PATH)" & $(MSBUILD) "$(PROJ_FILE)" /t:Rebuild /p:Configuration=Release

# pack project
pack: doc
	rmdir "$(PACK_DIR)" /s /q 2>nul
	mkdir "$(PACK_DIR)"

	mkdir "$(PACK_DOC_DIR)"
	xcopy /s "$(DOC_OUTPUT_DIR)\html" "$(PACK_DOC_DIR)"

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
	del "$(ROOT_DIR)\Calculator.sln.DotSettings.user"\
	"$(PROJ_DIR)\Calculator.csproj.user"\
	"$(TESTS_DIR)\Tests.csproj.user"\
	"$(TESTS_DIR)\StandardDeviation.csproj.user"\
	2>nul

	rmdir "$(ROOT_DIR)\.vs"\
	"$(ROOT_DIR)\packages"\
	"$(TEST_RESULT_DIR)"\
	"$(DOC_OUTPUT_DIR)"\
	"$(PROJ_DIR)\bin"\
	"$(PROJ_DIR)\obj"\
	"$(TESTS_DIR)\bin"\
	"$(TESTS_DIR)\obj"\
	"$(STANDARD_DEVIATION_DIR)\bin"\
	"$(STANDARD_DEVIATION_DIR)\obj"
	/s /q 2>nul

# run tests of math library
test: build_test
	del "$(TESTS_RESULT_FILE)" 2>nul
	cd "$(VISUAL_STUIDO_PATH)" & $(MSTEST) /testcontainer:"$(TESTS_CONTAINER)" /resultsfile:"$(TESTS_RESULT_FILE)"

build_test: nuget_test
	cd "$(VISUAL_STUIDO_PATH)" & $(MSBUILD) "$(TESTS_FILE)" /t:Rebuild /p:Configuration=Debug

nuget_test:
	cd "$(VISUAL_STUIDO_PATH)" & $(NUGET) restore -OutputDirectory "$(PACKAGES_DIR)" "$(TESTS_DIR)\$(PACKAGES_FILE)"

# generate program documentation
doc: Doxyfile
	doxygen $<

# run program
run: build
	$(PROJ)
