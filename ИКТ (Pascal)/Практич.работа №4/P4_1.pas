{“имушев 142гр}
Program P3_1;
uses crt;
var A: integer;
begin
writeln('¬ведите двухзначное число');
readln(A);
writeln((A div 10)*100+(A mod 10));
writeln(A*10);
writeln((A mod 10)*100+(A div 10));
writeln(((A mod 10)*10+(A div 10))*10);
end.