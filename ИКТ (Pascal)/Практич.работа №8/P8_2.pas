{Тимушев 142гр}
Program P8_2;
uses crt;
var s:string;
    i:integer;
    k:integer;{символы латинского алфавита}
begin
textbackground(green);
clrscr;
readln(s);
For i:=1 to Length(S) do
begin
If S[i] in [#65..#90,#97..#122] then k:=k+1;
end;
writeln(k);
GotoXY(40, 12);
for i:=length(s) downto 1 do
if s[i] in [#65..#90,#97..#122]then
delete(s,i,1);
writeln(s);
readln
end.
