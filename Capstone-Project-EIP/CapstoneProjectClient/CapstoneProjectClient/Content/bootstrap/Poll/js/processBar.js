function move() {
    var i = 1;
    while (i <= 3) {
        var classId = "myBar" + i;
        var demo = "demo" + i;
        var elem = document.getElementById(classId);
        var width = 0;
        (function Run(classId, demo, elem, width) {
            return new Promise(resolve => {
                var interval = setInterval(() => {
                    if (width >= 70) {
                        clearInterval(interval);
                    } else {
                        width++;
                        if (width <= 33) {
                            document.getElementById(classId).className = "progress-bar progress-bar-danger";
                        }
                        if (width > 33 && width <= 66) {
                            document.getElementById(classId).className = "progress-bar progress-bar-warning";
                        }
                        if (width > 66 && width <= 100) {
                            document.getElementById(classId).className = "progress-bar progress-bar-success";
                        }
                        elem.style.width = width + '%';
                        document.getElementById(demo).innerHTML = width + '%';
                    }

                }, 100);
            });
        })(classId, demo, elem, width);
        i++;



        //var id = setInterval(function () {
        //    if (width >= 70) {
        //        clearInterval(id);
        //    } else {
        //        width++;
        //        if (width <= 33) {
        //            document.getElementById(classId).className = "progress-bar progress-bar-danger";
        //        }
        //        if (width > 33 && width <= 66) {
        //            document.getElementById(classId).className = "progress-bar progress-bar-warning";
        //        }
        //        if (width > 66 && width <= 100) {
        //            document.getElementById(classId).className = "progress-bar progress-bar-success";
        //        }
        //        elem.style.width = width + '%';
        //        document.getElementById(demo).innerHTML = width + '%';
        //    }
        //}, 100);
    }
}