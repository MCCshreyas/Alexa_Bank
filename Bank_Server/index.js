var http = require("http");
var express = require('express');
var app = express();
var mysql = require('mysql');
var bodyParser = require('body-parser');

var connection = mysql.createConnection({
	host: 'localhost',
	user: 'root',
	password: '9970209265',
	database: 'BankApp'
});

connection.connect((err) => {
	if (err) {
		throw err;
	}
	console.log('You are now connected with mysql database...')
});

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
	extended: true
}));

// Server setup
var server = app.listen(3000, "127.0.0.1", () => {
	var host = server.address().address
	var port = server.address().port
	console.log("Example app listening at http://%s:%s", host, port)
});

//REST API section

app.get('/accounts', (req, res) => {
	connection.query('select Account_number from info', (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

app.get('/customer', (req, res) => {
	connection.query('select * from info', (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

app.get('/customer/:id', (req, res) => {
	connection.query('select * from info where Account_number=?', [req.params.id], (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

// We have to send data in JSON format 
/*
{ 	
	Name: 'Postman',  
	Address: 'chrome',
	Phone_number: '7757023365',  
	Email: 'postman@live.com',
	Password: '9970209265',  
	Account_number: '1234567890',
	Balance: 200,  
	ImagePath: '/something/something.jpg',  
	Gender: 'Male',
	MobileVerification: 'Yes',  
	BirthDate: '02/11/1997' 
}
*/
//following method will require json data to work
app.post('/customer', (req, res) => {
	var params = req.body;
	console.log(params);
	connection.query('INSERT INTO info SET ?', params, (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

//TO update name
app.put('/customer/updatename/:id/:name', (req, res) => {
	connection.query('UPDATE `info` SET `Name`= ? where `Account_number`= ?', [req.params.name, req.params.id], (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

// to update address
app.put('/customer/updateaddress/:id/:address', (req, res) => {
	connection.query('UPDATE `info` SET `Address`= ? where `Account_number`= ?', [req.params.address, req.params.id], (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

//To update phone number
app.put('/customer/updatephonenumber/:id/:phonenumber', (req, res) => {
	connection.query('UPDATE `info` SET `Phone_number`= ? where `Account_number`= ?', [req.params.phonenumber, req.params.id],  (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

//to update email address
app.put('/customer/updateemail/:id/:email', (req, res) => {
	connection.query('UPDATE `info` SET `Email`= ? where `Account_number`= ?', [req.params.email, req.params.id],(error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

// to update password
app.put('/customer/updatepassword/:id/:password', (req, res) => {
	connection.query('UPDATE `info` SET `Password`= ? where `Account_number`= ?', [req.params.password, req.params.id], (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

// to update account balance
app.put('/customer/updatebalance/:id/:balance', (req, res) => {
	connection.query('UPDATE `info` SET `Balance`= ? where `Account_number`= ?', [req.params.balance, req.params.id], (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

// to update Image path
app.put('/customer/updateImagePath/:id/:path', (req, res) => {
	connection.query('UPDATE `info` SET `ImagePath`= ? where `Account_number`= ?', [req.params.path, req.params.id], (error, results, fields)  => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

// to update gender
app.put('/customer/updategender/:id/:gender', (req, res) => {
	connection.query('UPDATE `info` SET `Gender`= ? where `Account_number`= ?', [req.params.gender, req.params.id], (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

// to update Mobile verification
app.put('/customer/updatemobileverification/:id/:mobile', (req, res) => {
	connection.query('UPDATE `info` SET `MobileVerification`= ? where `Account_number`= ?', [req.params.mobile, req.params.id], (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

// To update birth date
app.put('/customer/updatebirthdate/:id/:date', (req, res) => {
	connection.query('UPDATE `info` SET `BirthDate`= ? where `Account_number`= ?', [req.params.date, req.params.id],  (error, results, fields) => {
		if (error) throw error;
		res.end(JSON.stringify(results));
	});
});

//rest api to delete record from mysql database
app.delete('/customer/:id', (req, res) => {
   connection.query('DELETE FROM `info` WHERE `Account_Number`= ?', [req.params.id], (error, results, fields) => {
	  if (error) throw error;
	  res.end('Record has been deleted!');
	});
});