var form1 = document.form1; 
function vivv()
{
	var text = form1.txt.value;
	var raz = form1.txt2.value;
	var text2 = text.split(raz);
	form1.txt3.value= text2[text2.length-1];
}