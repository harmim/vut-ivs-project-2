#/**************************************************************
# * Team:      Disassembler
# *
# * Authors:   Vojtìch Hertl <xhertl04@stud.fit.vutbr.cz>
# *            Dominik Harmim <xharmi00@stud.fit.vutbr.cz>
# *            Timotej Halás <xhalas10@stud.fit.vutbr.cz>
# *            Matej Havlas <xhavla06@stud.fit.vutbr.cz>
# **************************************************************/

doc_path = ../doc

doc:
	doxygen
	make -C $(doc_path)
	mv $(doc_path)/refman.pdf $(doc_path)/documentation.pdf
	find ../doc ! -name 'documentation.pdf' -type f -exec rm -f {} +