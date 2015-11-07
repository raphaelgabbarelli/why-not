var express = require('express');
var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var _ = require('lodash');

app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');
});

app.use('/lib', express.static('lib'));

io.on('connection', function(socket){
  console.log('a user connected');

  socket.on('disconnect', function(){
    console.log('user disconnected');
  });

  var interval = setInterval(function () {
    var x = _.random(1, 100),
        y = _.random(1, 100),
        z = _.random(1, 100);

    socket.emit("msg", {'x': x, 'y': y, 'z': z});
  }, 1000);
});

http.listen(3000, function(){
  console.log('listening on *:3000');
});
