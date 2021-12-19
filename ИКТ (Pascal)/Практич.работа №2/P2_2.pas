{Тимушев Федор 142гр}
program P2_1;
uses crt;
var x,y: integer;
begin
clrscr;
TextBackGround(13);
clrscr;
Writeln('Введите 2 числа: ');
Readln(x);
Readln(y);
clrscr;
GotoXY(60,23); Writeln('(x-2)*(x-2)=',(x-2)*(x-2));
gotoXY(60,24); Writeln('(y-2)*(y-2)=',(y-2)*(y-2));
gotoXY(60,25); Writeln('(y*y*y)/(x*x*x)=',(y*y*y)/(x*x*x));
end.