var config = require("./server-config");
var orientDb = require("orientjs");

var dbServer = config.dbServer;
var readModelConfig = config.readModelStore;


var server = orientDb(
    {
        host: dbServer.host,
        port: dbServer.port,
        username: dbServer.username,
        password: dbServer.password
    }
);

var readModel = server.use(
    {
        name : readModelConfig.dbName,
        username : readModelConfig.username,
        password : readModelConfig.password
    }
);


exports.getProdukteDerKategorie = (req, res, next) => {
    
    var kategorie = req.params["kategorie"];
    
    readModel
        .select()
        .from("Produkt")
        .where({Kategorie:kategorie})
        .column("id")
        .column("Name")
        .column("Preis")
        .column("Kategorie")
        .all()
        .then((produkte) => res.json(200, produkte));
}