var gulp = require("gulp");
module.exports = gulp;
const glob = require('glob');
var window = {};
var fs = require('fs');
var elasticlunr = require('elasticlunr');
var config = require('./wwwroot/scripts/samplelist.js');
var beautify = require('json-beautify');
var configJson = JSON.parse(fs.readFileSync('./config.json'));
var fsPath = require('path');
require("@syncfusion/ej2-staging");

gulp.task('generate-searchlist', function () {
    console.log(config);
    generateSearchIndex(config.window.samplesList);
});

gulp.task('createLocale', function (done) {
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
    else {
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
        var hideOnDevice = sampleCollection.hideOnDevice;
        for (sample of sampleCollection.samples) {
            sample.component = component;
            sample.dir = directory;
            sample.parentId = puid;
            sample.hideOnDevice = hideOnDevice;
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

gulp.task('desValidation', function (done) {
    var files = glob.sync('./Views/*/*', {
        silent: true,
        ignore: [
            './Views/Shared/*', './Views/**/locale.json', './Views/**/fonts', './Views/**/icons', './Views/**/Index.cshtml', './Views/Grid/_DialogAddPartial.cshtml', './Views/Grid/_DialogEditPartial.cshtml'
        ]
    });
    var reg = /.*meta name([\S\s]*?)\/.*/g;
    var reg1 = /\"([^"]+)\"/g;
    var error = "";
    var des = "";
    for (var i = 573; i < files.length; i++) {
        var url = files[i].split('/')[2] + '/' + files[i].split('/')[3];
        var cshtml = fs.readFileSync(files[i], 'utf8');
        if (reg.test(cshtml)) {
            cshtml = cshtml.match(reg)[0].match(reg1)[1].replace(/"/g, "");
            if (!(cshtml.length >= 100) && (cshtml.length <= 160)) {
                error = error + url + ' description length should be between 100 to 160 characters\n';
            }
        } else {
            des = des + url + ' description needed\n';
        }
    }
    if (error || des) {
        if (!fs.existsSync('./cireports/logs')) {
            fs.mkdirSync('./cireports/logs', { recursive: true });
        }
        fs.writeFileSync('./cireports/logs/descriptionValidation.txt', error + des, 'utf-8');
        done();
    }
});

gulp.task('title-section', function () {
    var samplelists = config.window.samplesList;
    var errorFileList = [];
    for (let component of samplelists) {
        var samples = component.samples;
        var category = component.category;
        for (let sample of samples) {
            let componentName = sample.component;
            let controlCategory = componentName + ' Control';
            let metaControlCategory = componentName + ' control';
            if(category === 'Document Processing Libraries'){
                componentName = sample.component + ' library -';
                controlCategory = sample.component + ' Library';
                metaControlCategory = sample.component + ' library';
            }
            let featureName = sample.name;
            let url = sample.url;
            let dir = sample.dir;
            let path = `./Views/${dir}/${url}.cshtml`;
            let content = fileExistsWithCaseSync(path) ? fs.readFileSync(path, 'utf8').trim() : errorFileList.push(`Views/${dir}/${url}.cshtml`);
            let title = `ASP.NET Core ${componentName} ${featureName} Example - Syncfusion Demos `;
            if (typeof content === 'string') {
            if ((/@section Title\s?{/).test(content)) {
                content = content.replace(/@section Title+{([^}]*)}/g, `@section Title{
                    <title>${title}</title> 
                }`).trim();
            } else {
                content = content + `\n@section Title{
                 <title>${title}</title>
             }`;
            }
            
            let description = `This example demonstrates the ${featureName} in ASP.NET Core ${metaControlCategory}. Explore here for more details.`;
            if ((/@section Meta\s?{/).test(content)) {
                content = content.replace(/@section Meta+{([^}]*)}/g, `@section Meta{
                    <meta name="description" content="${description}"/>
                }`).trim();
            } else {
                content = content + `\n@section Meta{
                <meta name="description" content="${description}"/>
            }`;
            }
            let header = `Example of ${featureName} in ASP.NET Core ${controlCategory}`;
            if ((/@section Header\s?{/).test(content)) {
                content = content.replace(/@section Header+{([^}]*)}/g, `@section Header{
                    <h1 class='sb-sample-text'>${header}</h1>
                }`).trim();
            } else {
                content = content + `\n@section Header{
                <h1 class='sb-sample-text'>${header}</h1>
            }`;
            }
            fs.writeFileSync(path, content, 'utf-8');
            }
        }
    }
    if (errorFileList.length) {
        var fileName = '';
        var count = 0;
        for (var fileList of errorFileList) {
            fileName += `${++count}) ${fileList}\n`;
        }
        console.log(`The below Razor file (cshtml) name and the samplelist URL is mismatching / not equal. Please provide the Razor file (cshtml) name as like in samplelist URL.\n
Expected razor file name:\n\n${fileName}`);
        process.exit(1);
    }
});

function fileExistsWithCaseSync(filepath) {
    var dir = fsPath.dirname(filepath);
    var filenames = fs.readdirSync(dir);
    return filenames.indexOf(fsPath.basename(filepath)) !== -1;
}

const SITEMAP_TEMPLATE =
`<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">{{:URLS}}
</urlset>`;

const SITE_URL = `
    <url>
        <loc>{{:DemoPath}}</loc>
        <lastmod>{{:Date}}</lastmod>
    </url>`;

const LOCAL_SITE_URL = `
    <url>
        <type>{{:Type}}</type>
        <loc>{{:DemoPath}}</loc>
        <lastmod>{{:Date}}</lastmod>
    </url>`;

gulp.task('sitemap-generate', function () {
    let siteMapFile = SITEMAP_TEMPLATE;
    let date = new Date().toISOString().substring(0, 10);
    let link = 'https://ej2.syncfusion.com/aspnetcore';
    let xmlstring = '';
    let components = config.window.samplesList.map(com => { return { directory: com.directory, type: com.samples.map(list => { return list.type; }), sampleUrls: com.samples.map(samp => { return samp.url; }) }; });
    for (let component of components ? components : []) {
        let sampleUrls = component.sampleUrls;
        let sampleType = component.type;
        sampleUrls = sampleUrls ? sampleUrls : [];
        sampleType = sampleType ? sampleType : [];
        for (let i = 0; i < sampleUrls.length; i++) {
            let urls = SITE_URL;
            if (process.argv[4] === 'local-sitemap' && sampleType[i] === 'new') {
                urls = LOCAL_SITE_URL;
                urls = urls.replace(/{{:Type}}/g, 'new');
            }
            urls = urls.replace(/{{:DemoPath}}/g, `${link}/${component.directory}/${sampleUrls[i]}`);
            urls = urls.replace(/{{:Date}}/g, date);
            xmlstring += urls;
        }
    }
    siteMapFile = siteMapFile.replace(/{{:URLS}}/g, xmlstring);
    if (process.argv[4] === 'local-sitemap') {
        fs.writeFileSync('./' + configJson.appName + '-net6/wwwroot/sitemap-demos.xml', siteMapFile, 'utf-8');
    } else {
        fs.writeFileSync('./sitemap-demos.xml', siteMapFile, 'utf-8');
    }
});
