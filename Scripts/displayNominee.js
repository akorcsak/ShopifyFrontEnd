$(document).ready(function () {

    Nominate = function (title, year, movieArray)
    {
        movieArray.unshift(title + " (" + year + ")");

        var length =  movieArray.length;

        if (length < 6) {

            var ul = document.getElementById("nominateTitleList");
            var li = document.createElement("li");
            li.setAttribute("id", length);
            li.appendChild(document.createTextNode(movieArray[0]));

            var button = document.createElement("button");
            button.innerHTML = "Remove";

            li.appendChild(button)
            ul.appendChild(li);
            document.getElementById(title + year).disabled = true;
            $("#banner").hide();
        }

        else {
            $("#banner").show();
            movieArray.pop();
        }

        button.onclick = function () {
            var myLi = document.getElementById(length);
            myLi.parentNode.removeChild(myLi);
            movieArray.pop();
            document.getElementById(title + year).disabled = false;
            $("#banner").hide();
        }
        $(root).empty();
       
    }
});