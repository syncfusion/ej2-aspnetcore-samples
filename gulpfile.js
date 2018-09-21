var gulp = require("gulp");
module.exports = gulp;
const glob = require('glob');
var window = {};
var fs = require('fs');
var elasticlunr = require('elasticlunr');
var config = require('./wwwroot/scripts/samplelist.js');
var beautify = require('json-beautify');
require("@syncfusion/ej2-staging");

gulp.task('generate-searchlist', function () {
    console.log(config);
    generateSearchIndex(config.window.samplesList);
});

gulp.task('createLocale',function(done) {
    var localeJson = glob.sync('./Views/**/locale.json', {
        silent: true
    });
    if (localeJson.length) {
        var obj = [];
        for (var i = 0; i < localeJson.length; i++) {
            var compentLocale = JSON.parse(fs.readFileSync(localeJson[i]));
            obj.push(compentLocale);
            fs.writeFileSync('./wwwroot/scripts/locale-string.js', 'window.Locale = ' + JSON.stringify(obj));
        }
    }
    else
    {
        fs.writeFileSync('./wwwroot/scripts/locale-string.js', 'window.Locale = {}');
    }
});

function generateSearchIndex(data) {
    var result = [];
    var updatedList;
    var subCategory = [];
    var intId = 0;
    var addUID = function (pid, dt) {
        for (var i = 0; i < dt.length; i++) {
            dt[i].uid = pid + i;
            if (dt[i].hasOwnProperty('samples')) {
                curDirectory = dt[i].directory;
                subCategory = [];
                addUID('00' + intId + i, dt[i].samples);
                intId++;
                var isLast = intId === dt.length - 1;
            } else {
                var index = subCategory.indexOf(dt[i].category);
                if (index !== -1) {
                    dt[i].order = index;
                } else {
                    subCategory.push(dt[i].category);
                    dt[i].order = subCategory.length - 1;
                }
            }
        }
        updatedList = dt;
        if (isLast) {
            fs.writeFileSync('./wwwroot/scripts/samplelist.js', JSON.stringify(updatedList), null, '\t');
        }
    }
    var sampleOrder = JSON.parse(fs.readFileSync('./wwwroot/scripts/sampleOrder.json', 'utf8'));
    var orderKeys = Object.keys(sampleOrder);
    for (var i = 0; i < orderKeys.length; i++) {
        var components = sampleOrder[orderKeys[i]];
        for (var j = 0; j < components.length; j++) {
            var currentData = getSamples(data, components[j]);
            currentData['order'] = i;
            result.push(currentData);
        }
    }
    addUID("0", result);
    // generateSearchIndex(result);
    //  return new Buffer('window.samplesList  =' + JSON.stringify(result) + ';\n\n' + 'window.apiList =' + JSON.stringify(apiReference));

    elasticlunr.clearStopWords();
    var instance = elasticlunr(function () {
        this.addField('component');
        this.addField('name');
        this.setRef('uid');
    });
    for (sampleCollection of data) {

        var component = sampleCollection.name;
        var directory = sampleCollection.directory;
        var puid = sampleCollection.uid;
        for (sample of sampleCollection.samples) {
            sample.component = component;
            sample.dir = directory;
            sample.parentId = puid;
            instance.addDoc(sample);
        }
    }
    var string = `if (!window) {

        var window = exports.window = {};
    }
    window.samplesList =`;

    fs.writeFileSync('./wwwroot/scripts/samplelist.js', string + beautify(updatedList, null, 2, 100));
    fs.writeFileSync('./wwwroot/scripts/search-index.js', 'window.searchIndex = ' + JSON.stringify(instance.toJSON()));

}

function getSamples(data, component) {
    for (var i = 0; i < data.length; i++) {
        if (component === data[i].directory) {
            return data[i];
        }
    }
}
