{Тимушев 142гр}
Program P8_1;
uses crt;
var s:string;
    i:integer;
begin
textbackground(green);
clrscr;
readln(s);
GotoXY(40, 12);
for i:=length(s) downto 1 do
if s[i] in [#65..#90,#97..#122]then
delete(s,i,1);
writeln(s);
readln
end.
