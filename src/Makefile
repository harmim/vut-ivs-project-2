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

ROOT_DIR:=$(shell cd)\..
VISUAL_STUIDO_PATH=C:\Programs\Microsoft Visual Studio\2017\Enterprise
MSBUILD=MSBuild\15.0\Bin\MSBuild.exe
MSTEST=Common7\IDE\MSTEST.exe
NUGET=MSBuild\ReadyRoll\OctoPack\tools\NuGet.exe
DEVENV=Common7\IDE\devenv.com
PACKAGES_FILE=packages.config
PACKAGES_DIR=$(ROOT_DIR)\packages

PROJ_NAME=Calculator
PROJ_DIR=$(ROOT_DIR)\src\$(PROJ_NAME)
PROJ=$(PROJ_DIR)\bin\Release\$(PROJ_NAME).exe
PROJ_FILE=$(PROJ_DIR)\$(PROJ_NAME).csproj

TESTS_NAME=Tests
TESTS_DIR=$(ROOT_DIR)\src\$(TESTS_NAME)
TESTS_CONTAINER=$(ROOT_DIR)\src\$(TESTS_NAME)\bin\Debug\$(TESTS_NAME).dll
TEST_RESULT_DIR=$(ROOT_DIR)\TestResults
TESTS_RESULT_FILE=$(TEST_RESULT_DIR)\Result_file
TESTS_FILE=$(TESTS_DIR)\$(TESTS_NAME).csproj

PACK_NAME=xharmi00_xhalas10_xhavla06_xhertl04
PACK_ARCHIVE=$(ROOT_DIR)\$(PACK_NAME).zip
PACK_DIR:=$(ROOT_DIR)\..\$(PACK_NAME)
PACK_DOC_DIR=$(PACK_DIR)\doc
PACK_INSTALL_DIR=$(PACK_DIR)\install
PACK_REPO_DIR=$(PACK_DIR)\repo

DOC_OUTPUT_DIR=$(ROOT_DIR)\src\doxygen_output

STANDARD_DEVIATION_NAME=StandardDeviation
STANDARD_DEVIATION_DIR=$(ROOT_DIR)\src\$(STANDARD_DEVIATION_NAME)

INSTALLER_NAME=Setup
INSTALLER_DIR=$(ROOT_DIR)\src\$(INSTALLER_NAME)
INSTALLER_FILE=$(INSTALLER_DIR)\$(INSTALLER_NAME).vdproj

.PHONY: all build pack installer clean test build_test nuget_test doc run

# default target => build project
all: build

# build Release project
build:
	cd "$(VISUAL_STUIDO_PATH)" & $(MSBUILD) "$(PROJ_FILE)" /t:Build /p:Configuration=Release

# pack project
pack: doc installer
	if exist "$(PACK_DIR)" del "$(PACK_DIR)" /f /s /q 1>nul & rmdir "$(PACK_DIR)" /s /q
	mkdir "$(PACK_DIR)"

	mkdir "$(PACK_DOC_DIR)"
	xcopy /s "$(DOC_OUTPUT_DIR)\html" "$(PACK_DOC_DIR)"

	mkdir "$(PACK_INSTALL_DIR)"
	xcopy /s "$(INSTALLER_DIR)\Release" "$(PACK_INSTALL_DIR)"

	mkdir "$(PACK_REPO_DIR)"
	make clean
	xcopy /s "$(ROOT_DIR)" "$(PACK_REPO_DIR)"
	mkdir "$(PACK_REPO_DIR)\.git"
	xcopy /s "$(ROOT_DIR)\.git\*" "$(PACK_REPO_DIR)\.git"

	cd "$(PACK_DIR)\.." & zip -r "$(PACK_ARCHIVE)" $(PACK_NAME)
	del "$(PACK_DIR)" /f /s /q 1>nul
	rmdir "$(PACK_DIR)" /s /q

installer: nuget_test
# bug in Visual Studio 2017 see http://www.kunal-chowdhury.com/2016/07/visual-studio-error-code-8000000A.html#RY4kZKbC2JYg4vVG.97
	cd "$(VISUAL_STUIDO_PATH)" & $(DEVENV) "$(INSTALLER_FILE)" /build Release

# clean all temp files
FILES_TO_REMOVE="$(ROOT_DIR)\Calculator.sln.DotSettings.user" "$(PROJ_DIR)\$(PROJ_NAME).csproj.user" "$(TESTS_DIR)\$(TESTS_NAME).csproj.user" "$(STANDARD_DEVIATION_DIR)\$(STANDARD_DEVIATION_NAME).csproj.user"
DIRS_TO_REMOVE="$(ROOT_DIR)\.vs" "$(PACKAGES_DIR)" "$(TEST_RESULT_DIR)" "$(DOC_OUTPUT_DIR)" "$(PROJ_DIR)\bin" "$(PROJ_DIR)\obj" "$(TESTS_DIR)\bin" "$(TESTS_DIR)\obj" "$(STANDARD_DEVIATION_DIR)\bin" "$(STANDARD_DEVIATION_DIR)\obj" "$(INSTALLER_DIR)\Debug" "$(INSTALLER_DIR)\Release"
clean:
	for %%f in ($(FILES_TO_REMOVE)) do ( if exist %%f del %%f )
	for %%d in ($(DIRS_TO_REMOVE)) do ( if exist %%d del %%d /f /s /q 1>nul & rmdir %%d /s /q )
	if exist "$(PACK_ARCHIVE)" del "$(PACK_ARCHIVE)"

# run tests of math library
test: build_test
	if exist "$(TESTS_RESULT_FILE)" del "$(TESTS_RESULT_FILE)"
	if not exist "$(TEST_RESULT_DIR)" mkdir "$(TEST_RESULT_DIR)"
	cd "$(VISUAL_STUIDO_PATH)" & $(MSTEST) /testcontainer:"$(TESTS_CONTAINER)" /resultsfile:"$(TESTS_RESULT_FILE)"

# build test
build_test: nuget_test
	cd "$(VISUAL_STUIDO_PATH)" & $(MSBUILD) "$(TESTS_FILE)" /t:Build /p:Configuration=Debug

# download nuget packages for test
nuget_test:
	cd "$(VISUAL_STUIDO_PATH)" & $(NUGET) restore -OutputDirectory "$(PACKAGES_DIR)" "$(TESTS_DIR)\$(PACKAGES_FILE)"

# generate program documentation
doc: Doxyfile
	doxygen $<

# run program
run:
	if not exist "$(PROJ)" make build
	$(PROJ)
