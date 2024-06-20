const {JSDOM} = require('jsdom');
//import {JSDOM} from 'jsdom';
const fs = require('fs');
const path = require('path');

test('simple button click',()=>{
    const html= fs.readFileSync(path.resolve(__dirname,'../index.html'),'utf8');
    const dom = new JSDOM(html
        ,{runScripts: 'dangerously',resources: 'usable'});
    //Adding the script file
    const script = fs.readFileSync(path.resolve(__dirname,'../Script.js'),'utf8');
    const scriptEl = dom.window.document.createElement('script');
    scriptEl.textContent = script;
    dom.window.document.body.appendChild(scriptEl);

        //Raising the event
    dom.window.document.getElementById('btn').click();
    const actual = dom.window.document.getElementById('demo').innerHTML;
    expect(actual).toBe('Hello World');
})