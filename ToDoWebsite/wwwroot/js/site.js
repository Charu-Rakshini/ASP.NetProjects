// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.






function onCopy(taskName) {
    alert("Trying to copy task");
    
    
    document.getElementById("btnCopyTask").addEventListener("click", function () {
        //var user_name = document.getElementById("#taskTitleText");
        alert(taskName);
        val=navigator.clipboard.write(new ClipboardItem(taskName));
   //// var value = user_name.value.trim();
   //     if (taskName)
   //     alert("Task cannot be copied!");
   // else {
   //         navigator.clipboard.write(new ClipboardItem(taskName));
   //     }

    });
}


document.getElementById('status').innerHTML = navigator.onLine ? 'online' : 'offline';

var target = document.getElementById('target');

function handleStateChange() {
    var timeBadge = new Date().toTimeString().split(' ')[0];
    var newState = document.createElement('p');
    var state = navigator.onLine ? 'online' : 'offline';
    if (state = true) {
        document.getElementById("createForm").style.display = "none";
    } else {
        document.getElementById("createForm").style.display = "block";
    }
    newState.innerHTML = '' + timeBadge + ' Connection state changed to ' + state + '.';
    target.appendChild(newState);
}

window.addEventListener('online', handleStateChange);