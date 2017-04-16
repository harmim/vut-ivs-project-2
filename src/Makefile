#/**************************************************************
# * Team:      Disassembler
# *
# * Authors:   Vojtìch Hertl <xhertl04@stud.fit.vutbr.cz>
# *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
# *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
# *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
# **************************************************************/

doc_path = ..\doc

doc:
	doxygen
	"$(doc_path)\make.bat"
	rename "..\doc\refman.pdf" "documentation.pdf"
	for %%i in ($(doc_path)\*) do if not "%%i" == "$(doc_path)\documentation.pdf" del "%%i"