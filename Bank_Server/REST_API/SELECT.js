var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var conn = require('./../connection');
var server = require('./../server');

function getAllCustomers() {
    app.get('/user', function (req, res) {
        connection.query('select * from user', function (error, results, fields) {
            if (error) throw error;
            res.end(JSON.stringify(results));
        });
    });
}

module.exports.getAllCustomers = getAllCustomers;