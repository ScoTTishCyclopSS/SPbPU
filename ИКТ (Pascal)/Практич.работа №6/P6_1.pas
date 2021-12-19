{Тимушев 142гр}
Program P6_1;
uses crt;
var s:real;
    El:real;
    i:integer;
begin
    ClrScr;
    S:=0;
    For i:=0 to 12 do
     begin
     El:=1/(power(3,i));
     S:=S+el;
     end;
   Writeln('S=',S);
  Readln;
  End.
    