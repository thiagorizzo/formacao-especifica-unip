var expressClass = require('express');
var produtos = require('./produtos');
var bodyParser = require('body-parser');
var cors = require('cors');

var express = new expressClass();

express.use(cors());

express.use(function (req, res, next) {
    // Website you wish to allow to connect
    //res.setHeader('Access-Control-Allow-Origin', 'http://localhost:4200');

    // Request methods you wish to allow
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, PUT, PATCH, DELETE');

    // Request headers you wish to allow
    res.setHeader('Access-Control-Allow-Headers', 'X-Requested-With,content-type');

    // Set to true if you need the website to include cookies in the requests sent
    // to the API (e.g. in case you use sessions)
    res.setHeader('Access-Control-Allow-Credentials', true);

    // Pass to next layer of middleware
    next();
});


express.use(bodyParser.json());
express.use(bodyParser.urlencoded({
    extended: true
}));

express.get('/Produto/:codigo', function(request, response) {
    var codigo = request.params["codigo"];
    var promise = new Promise(
        (resolve, reject) => {
            resolve(produtos.filter(produto => {
                return produto.codigo == codigo
            })[0]);
        }
    );
    promise.then(produto => {
        response.json(produto);
    });
});

express.get('/Produtos', function(request, response) {
	response.json(produtos);
});

express.post('/Produtos', function(request, response) {
    console.log(JSON.stringify(request.body));
    produtos.push(request.body);
    response.json(produtos);
});

express.delete("/Produtos/:codigo", function(request, response) {
    var codigo = request.params["codigo"];
    produtos = produtos.filter(function(p) {
        return p.codigo != codigo;
    });
    console.log(produtos);
    response.json(produtos);
});

express.listen(8888);