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
var shelljs = require('shelljs');
const { title } = require("process");
require("@syncfusion/ej2-staging");

gulp.task('generate-searchlist', function (done) {
    console.log(config);
    generateSearchIndex(config.window.samplesList);
    done();
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
    done();
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
    done();
});


function adjustTitle(componentName, featureName) {
    const shortTemplates = [
        `Learn about ${featureName} in ASP.NET Core ${componentName} - Syncfusion Demos`,
        `${featureName} feature in ASP.NET Core ${componentName} - Try it now!`
    ];

    const longTemplates = [
        `ASP.NET Core ${componentName} ${featureName} - Syncfusion`,
        `${featureName} Example using ASP.NET Core ${componentName} - Syncfusion`
    ];

    const base = `ASP.NET Core ${componentName} ${featureName} Example - Syncfusion Demos`;
    const baseLength = base.length;

    if (baseLength < 50) {
        for (let template of shortTemplates) {
            if (template.length >= 50 && template.length <= 70) {
                return template;
            }
        }
    } else if (baseLength > 70) {
        for (let template of longTemplates) {
            if (template.length >= 50 && template.length <= 70) {
                return template;
            }
        }
    } else {
        return base;
    }
    // If no suitable template found, return the base title with adjustments
    return base.length > 70 ? base.substring(0, 67) + '...' : base.padEnd(50, '.');
}

function adjustDescription(featureName, metaControlCategory) {
    const shortTemplates = [
        `Explore the ${featureName} in ASP.NET Core ${metaControlCategory}. Learn how it helps improve your app's functionality.`,
        `This example shows how ${featureName} works in ASP.NET Core ${metaControlCategory}. Understand its purpose and usage.`,
        `Discover the ${featureName} feature in ASP.NET Core ${metaControlCategory}. Learn how to use it in real-world scenarios.`,
        `Learn how to use ${featureName} in ASP.NET Core ${metaControlCategory}. This guide helps you integrate it effectively.`,
        `Understand the ${featureName} in ASP.NET Core ${metaControlCategory}. See how it enhances your development workflow.`,
        `Explore ${featureName} in ASP.NET Core ${metaControlCategory}. Learn how to configure and apply it in your projects.`
    ];

    const longTemplates = [
        `This example demonstrates the ${featureName} in ASP.NET Core ${metaControlCategory}. Discover its capabilities, integration steps, and customization options.`,
        `Explore the ${featureName} feature in ASP.NET Core ${metaControlCategory}. Learn how to use it effectively and integrate it into your application with best practices.`,
        `Understand how ${featureName} works in ASP.NET Core ${metaControlCategory}. This guide covers usage, configuration, and advanced customization.`,
        `This demo shows how to use ${featureName} in ASP.NET Core ${metaControlCategory}, including setup, configuration, and real-world implementation tips.`,
        `Discover the benefits of using ${featureName} in ASP.NET Core ${metaControlCategory}. Learn how to apply it efficiently in your business apps.`,
        `Explore ${featureName} in ASP.NET Core ${metaControlCategory}. This example covers integration, customization, and practical usage scenarios.`
    ];
    const base = `This example demonstrates the ${featureName} feature in ASP.NET Core ${metaControlCategory}.Learn how it works and how to integrate it into your application.`
    const baseLength = base.length;
    if (baseLength < 150) {
        for (let template of shortTemplates) {
            if (template.length >= 150 && template.length <= 160) 
                return template;
        }
    } else if (baseLength > 160) {
        for (let template of longTemplates) {
            if (template.length >= 150 && template.length <= 160) 
                return template;
        }
    }
    if(baseLength < 146 && baseLength > 135){
        return base + ' Explore here.';
    }
    if (baseLength < 150 && baseLength > 145) {
        return base + 'Check now.'; 
    } 
    if (baseLength > 160) {
        return base.substring(0, 157) + '...'; 
    }
    return base;
}


gulp.task('title-section', function (done) {
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
            let path = `./Pages/${dir}/${url}.cshtml`; 
            let content;
            if (fileExistsWithCaseSync(path)) {
                content = fs.readFileSync(path, 'utf8').trim();
            }
            else {
                path = path.replace("Pages", "Views");
                if (fileExistsWithCaseSync(path)) {
                    content = fs.readFileSync(path, 'utf8').trim();
                } else {
                    errorFileList.push(fsPath.basename(path));
                }
            }      
            var title = adjustTitle(componentName, featureName);
            if(title.length > 70 || title.length < 50) {
                throw new Error(`error: The title for ${featureName} in ${componentName} is not within the recommended length. Please adjust it.`);
            }
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
            
            var description = adjustDescription(featureName, metaControlCategory);
            if(description.length > 160 || description.length < 150) {
                throw new Error(`error: The description for ${featureName} in ${componentName} is not within the recommended length. Please adjust it.`);
            }
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
    done();
});

function fileExistsWithCaseSync(filepath) {
    var checkPath = (path) => {
        var dir = fsPath.dirname(path);
        try {
            var filenames = fs.readdirSync(dir);
            return filenames.indexOf(fsPath.basename(filepath)) !== -1;
        } catch (err) {
            // If an error occurs (e.g., directory does not exist), return false
            return false;
        }
    };
    return checkPath(filepath);
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

gulp.task('sitemap-generate', function (done) {
    let siteMapFile = SITEMAP_TEMPLATE;
    let date = new Date().toISOString().substring(0, 10);
    let link = 'https://ej2.syncfusion.com/aspnetcore/demos';
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
            urls = urls.replace(/{{:DemoPath}}/g, `${link}/${component.directory.toLowerCase()}/${sampleUrls[i].toLowerCase()}`);
            urls = urls.replace(/{{:Date}}/g, date);
            xmlstring += urls;
        }
    }
    siteMapFile = siteMapFile.replace(/{{:URLS}}/g, xmlstring);
    if (process.argv[4] === 'local-sitemap') {
        fs.writeFileSync('./' + configJson.appName + '-net10/wwwroot/sitemap-demos.xml', siteMapFile, 'utf-8');
    } else {
        fs.writeFileSync('./sitemap-demos.xml', siteMapFile, 'utf-8');
    }
    done();
});

gulp.task('code-leaks-analysis', function (done) {
    var codeLeaksReport = JSON.parse(fs.readFileSync('GitLeaksReport.json', 'utf-8'));
    if (Object(codeLeaksReport).length <= 0) {
        console.log("<- No Leaks Found ->");
        shelljs.exec('rm GitLeaksReport.json')
    }
    else {
        throw "Please clear the Git Leaks reported issues";
    }
    done();
});
