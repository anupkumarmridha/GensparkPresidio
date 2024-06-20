const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');

test('simple login success',()=>{
    const html= fs.readFileSync(path.resolve(__dirname,'../Login.html'),'utf8');
    const dom = new JSDOM(html
        ,{runScripts: 'dangerously',resources: 'usable'});
    //Adding the script file
    const script = fs.readFileSync(path.resolve(__dirname,'../Login.js'),'utf8');
    const scriptEl = dom.window.document.createElement('script');
    scriptEl.textContent = script;
    dom.window.document.body.appendChild(scriptEl);

    dom.window.document.getElementById('email').value='user1@example.com';
    dom.window.document.getElementById('password').value='password1';

        //Raising the event
    dom.window.document.getElementById('loginBtn').click();

    const actual = dom.window.document.getElementById('demo').innerHTML;    
    expect(actual).toBe('Login successful!');

})

test('simple login failure',()=>{
    const html  = fs.readFileSync(path.resolve(__dirname,'../Login.html'),'utf8');
    const dom = new JSDOM(html
        ,{runScripts: 'dangerously',resources: 'usable'});
    //Adding the script file
    const script = fs.readFileSync(path.resolve(__dirname,'../Login.js'),'utf8');
    const scriptEl = dom.window.document.createElement('script');
    scriptEl.textContent = script;
    dom.window.document.body.appendChild(scriptEl);
    dom.window.document.getElementById('email').value='user1@example.com';
    dom.window.document.getElementById('password').value='passwor1';

        //Raising the event
    dom.window.document.getElementById('loginBtn').click();

    const actual = dom.window.document.getElementById('demo').innerHTML;    
    expect(actual).toBe('Invalid email or password');
})