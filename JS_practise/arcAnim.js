"use strict";

// Контекст. Главные команды
let c = document.getElementById("cnv"); // взяли елемент html документа - канвас
let cntx = c.getContext("2d"); // взяли набор инструментов для рисования -
                        // контекст. Он может быть 2d или webgl(3d)


// Начинаем рисовать
/*cntx.beginPath(); // мы собираемся рисовать
cntx.moveTo(0,0); // ставим курсор ( точку рисования ) в начальную позицию
cntx.lineTo(600,600); // проводим линию
cntx.lineTo(600,0);
cntx.lineTo(0,600);
cntx.lineWidth = 20; // задаем размер
cntx.strokeStyle = "#FFFF00"; // задаем цвет
cntx.lineCap = "butt"; // указываем вид углов линии( их не видно тут )
cntx.stroke(); // подтверждаем её, делаем видимой*/

// Нарисуем  arc



let arcFlag = false, i = 0,arcDrawer;
function drawArc( e ){
	let k;

    if( e.key == "ArrowUp" ) {
		k = 0.003;

		if( i == 0 ) {
			arcDrawer = setInterval(fillArc1, 10, k);
		}
	} else if( e.key == "ArrowDown" ) {
		k = -0.003;
		//console.log( i ) ;
		if( i > 2 ) {
			arcDrawer = setInterval(fillArc1, 10, k);
		}
	}
	
	//console.log( e.key + " " + arcEndAngle ) ;
}

function fillArc1( j ){
	i += j;
	cntx.clearRect(0,0,c.width,c.height); // очищаем
	cntx.beginPath();
	cntx.arc( c.height/2, c.width/2, 200, 0 , i * Math.PI, false );
	// x, y, radius, startAngle, endAngle, counterClockwise
	cntx.strokeStyle = 'green';
	cntx.lineWidth = 30;
	cntx.stroke();
	if( i < j * -1 ) {
		//console.log( i );
		cntx.clearRect(0,0,c.width,c.height);
		i = 0;
		clearInterval( arcDrawer )
	} 

	i > 2  && clearInterval( arcDrawer ); // отключаем рисование
}


document.addEventListener("keydown",drawArc);

// Нарисуем прямоугольник
/*cntx.fillStyle = "#00ffff";
cntx.fillRect(150,150,300,300); //  x,y,width,height
*/
