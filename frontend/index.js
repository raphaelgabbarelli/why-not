var express = require('express');
var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var _ = require('lodash');

app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');
});

app.use('/lib', express.static('lib'));
app.use('/models', express.static('models'));
app.use('/img', express.static('img'));

var cnt = 0;

io.on('connection', function(socket){
  console.log('a user connected');

  socket.on('disconnect', function(){
    console.log('user disconnected');
  });

  var interval = setInterval(function () {
    cnt++;
    var x = Math.sin(cnt/10)*800 - 1500,
        y = Math.cos(cnt/10)*100 + 100,
        z = 0;

    socket.emit("msg", {'x': x, 'y': y, 'z': z});
  }, 30);
});

http.listen(3000, function(){
  console.log('listening on *:3000');
});
