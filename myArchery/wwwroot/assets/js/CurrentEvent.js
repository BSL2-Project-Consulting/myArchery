function myChart1(hitted, missed) {
    let labels1 = ['Hitted', 'Missed'];
    let data1 = [missed, hitted];               //User Data per User how often he missed
    let colors1 = ['#49A9EA', '#36CAAB'];

    let myDoughnutChart = document.getElementById("myChart").getContext('2d');

    let chart1 = new Chart(myDoughnutChart, {
        type: 'doughnut',
        data: {
            labels: ['Hitted', 'Missed'],
            datasets: [{
                data: [hitted, missed],      //User Data per User how often he missed
                backgroundColor: ['#49A9EA', '#36CAAB']
            }]
        },
        options: {
            title: {
                text: "How accurate is my aim?",
                display: true
            }
        }
    });

}



function myChart2(ponitsPerArrow, ponitsPerArrowLength, targetname, targetlaenge) {



    let array = [];

    for (var i = 0; i < targetlaenge - 1; i++) {
        array.push(targetname);
        let labels2 = array[i];
    }

    let array2 = [];

    for (var i = 0; i < pointsPerArrowLength; i++) {
        array2.push(pointsPerArrow);
        let data2 = array2[i];// Points per User per animal
    }


    let colors2 = ['#49A9EA', '#36CAAB', '#34495E', '#B370CF'];

    let myChart2 = document.getElementById("myChart2").getContext('2d');

    let chart2 = new Chart(myChart2, {
        type: 'bar',
        data: {
            labels: labels2,
            datasets: [{
                data: data2,
                backgroundColor: colors2
            }]
        },
        options: {
            title: {
                text: "Ponits per Target per User",
                display: true
            },
            legend: {
                display: false
            }
        }
    });

}

function myChart3() {

    let datas = [1, 2, 3, 4, 5];
    let username = ['user1', 'user2'];



    let labels3 = ['Target 1', 'Target 2', 'Target 3', 'Target 4'];    // All animals
    let myChart3 = document.getElementById("myChart3").getContext('2d');

    let chart3 = new Chart(myChart3, {
        type: 'radar',
        data: {
            labels: labels3,
            datasets: [
                {
                    label: 'Messi',     //Username
                    fill: true,
                    backgroundColor: "rgba(179, 181, 198, 0.2)",
                    borderColor: "rgba(179, 181, 198, 1)",
                    pointBorderColor: "#fff",
                    pointBackgroundColor: "rgba(179, 181, 198, 1)",
                    data: [52, 55, 7, 29]  //User datas per User how much points per animal
                },
                {
                    label: 'Ronaldo',   //Username
                    fill: true,
                    backgroundColor: "rgba(255, 99, 132, 0.2)",
                    borderColor: "rgba(255, 99, 132, 1)",
                    pointBorderColor: "#fff",
                    pointBackgroundColor: "rgba(255, 99, 132, 1)",
                    data: [50, 32, 20, 44]      //User datas per User how much points per animal
                }
            ]
        },
        options: {
            title: {
                text: "Aim",
                display: true
            }
        }
    });

}

function myChart4(username,usernameLength, overallPoints, overallPointsLength) {

    let array5 = [];

    for (var i = 0; i < usernameLength - 1; i++) {
        array5.push(username);
        let labels4 = array5[i];
    }


    let array6 = [];

    for (var i = 0; i < overallPointsLength - 1; i++) {
        array6.push(overallPoints);
        let data4 = array6[i];
    }




    let colors4 = ['#49A9EA', '#36CAAB', '#34495E', '#B370CF', '#AC5353', '#CFD4D8'];

    let myChart4 = document.getElementById("myChart4").getContext('2d');

    let chart4 = new Chart(myChart4, {
        type: 'pie',
        data: {
            labels: labels4,
            datasets: [{
                data: data4,
                backgroundColor: colors4
            }]
        },
        options: {
            title: {
                text: "Over all Points per User",
                display: true
            }
        }
    });
    function toggle_visibility(buttonId, dotId) {


        var button = document.getElementById(buttonId)
        var dot = document.getElementById(dotId);

        if (dot.style.visibility == 'hidden') {
            dot.style.visibility = 'visible';
            button.style.color = buttonIdToColor[buttonId];
        } else {
            dot.style.visibility = 'hidden';
            button.style.color = 'black';
        }
    }

}
