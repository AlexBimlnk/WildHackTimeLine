(function(e){function t(t){for(var c,i,s=t[0],o=t[1],u=t[2],l=0,d=[];l<s.length;l++)i=s[l],Object.prototype.hasOwnProperty.call(a,i)&&a[i]&&d.push(a[i][0]),a[i]=0;for(c in o)Object.prototype.hasOwnProperty.call(o,c)&&(e[c]=o[c]);b&&b(t);while(d.length)d.shift()();return r.push.apply(r,u||[]),n()}function n(){for(var e,t=0;t<r.length;t++){for(var n=r[t],c=!0,i=1;i<n.length;i++){var s=n[i];0!==a[s]&&(c=!1)}c&&(r.splice(t--,1),e=o(o.s=n[0]))}return e}var c={},i={app:0},a={app:0},r=[];function s(e){return o.p+"js/"+({}[e]||e)+"."+{"chunk-8b2b73cc":"f7b2b384","chunk-e64e3e10":"d4d33242","chunk-f791cfb4":"3dc3c1ca"}[e]+".js"}function o(t){if(c[t])return c[t].exports;var n=c[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,o),n.l=!0,n.exports}o.e=function(e){var t=[],n={"chunk-8b2b73cc":1,"chunk-e64e3e10":1,"chunk-f791cfb4":1};i[e]?t.push(i[e]):0!==i[e]&&n[e]&&t.push(i[e]=new Promise((function(t,n){for(var c="css/"+({}[e]||e)+"."+{"chunk-8b2b73cc":"edb67fa2","chunk-e64e3e10":"aa97b1b9","chunk-f791cfb4":"f740b322"}[e]+".css",a=o.p+c,r=document.getElementsByTagName("link"),s=0;s<r.length;s++){var u=r[s],l=u.getAttribute("data-href")||u.getAttribute("href");if("stylesheet"===u.rel&&(l===c||l===a))return t()}var d=document.getElementsByTagName("style");for(s=0;s<d.length;s++){u=d[s],l=u.getAttribute("data-href");if(l===c||l===a)return t()}var b=document.createElement("link");b.rel="stylesheet",b.type="text/css",b.onload=t,b.onerror=function(t){var c=t&&t.target&&t.target.src||a,r=new Error("Loading CSS chunk "+e+" failed.\n("+c+")");r.code="CSS_CHUNK_LOAD_FAILED",r.request=c,delete i[e],b.parentNode.removeChild(b),n(r)},b.href=a;var m=document.getElementsByTagName("head")[0];m.appendChild(b)})).then((function(){i[e]=0})));var c=a[e];if(0!==c)if(c)t.push(c[2]);else{var r=new Promise((function(t,n){c=a[e]=[t,n]}));t.push(c[2]=r);var u,l=document.createElement("script");l.charset="utf-8",l.timeout=120,o.nc&&l.setAttribute("nonce",o.nc),l.src=s(e);var d=new Error;u=function(t){l.onerror=l.onload=null,clearTimeout(b);var n=a[e];if(0!==n){if(n){var c=t&&("load"===t.type?"missing":t.type),i=t&&t.target&&t.target.src;d.message="Loading chunk "+e+" failed.\n("+c+": "+i+")",d.name="ChunkLoadError",d.type=c,d.request=i,n[1](d)}a[e]=void 0}};var b=setTimeout((function(){u({type:"timeout",target:l})}),12e4);l.onerror=l.onload=u,document.head.appendChild(l)}return Promise.all(t)},o.m=e,o.c=c,o.d=function(e,t,n){o.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},o.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},o.t=function(e,t){if(1&t&&(e=o(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(o.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var c in e)o.d(n,c,function(t){return e[t]}.bind(null,c));return n},o.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return o.d(t,"a",t),t},o.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},o.p="/",o.oe=function(e){throw console.error(e),e};var u=window["webpackJsonp"]=window["webpackJsonp"]||[],l=u.push.bind(u);u.push=t,u=u.slice();for(var d=0;d<u.length;d++)t(u[d]);var b=l;r.push([0,"chunk-vendors"]),n()})({0:function(e,t,n){e.exports=n("56d7")},"025a":function(e,t,n){"use strict";n("f065")},"0313":function(e,t,n){},"0716":function(e,t,n){"use strict";n("0313")},2528:function(e,t,n){"use strict";n("8191")},"32ad":function(e,t,n){"use strict";n("9911");var c=n("7a23"),i=function(e){return Object(c["w"])("data-v-194cfc08"),e=e(),Object(c["u"])(),e},a={class:"timeline-event"},r=["href"],s={class:"card timeline-content"},o={class:"card-content teal white-text"},u=i((function(){return Object(c["h"])("div",{class:"timeline-badge red lighten-3 white-text"},null,-1)})),l={class:"year"};function d(e,t,n,i,d,b){return Object(c["t"])(),Object(c["g"])("div",a,[Object(c["h"])("a",{href:n.content.link},[Object(c["h"])("div",s,[Object(c["h"])("div",o,[Object(c["h"])("p",null,Object(c["C"])(n.content.title),1)])])],8,r),u,Object(c["h"])("div",l,Object(c["C"])(n.content.date),1)])}var b={props:{content:{type:Object}}},m=(n("2528"),n("6b0d")),f=n.n(m);const p=f()(b,[["render",d],["__scopeId","data-v-194cfc08"]]);t["a"]=p},"3fbd":function(e,t,n){"use strict";n("eda8")},"56d7":function(e,t,n){"use strict";n.r(t);n("e260"),n("e6cf"),n("cca6"),n("a79d");var c=n("7a23");function i(e,t,n,i,a,r){var s=Object(c["A"])("main-navbar"),o=Object(c["A"])("router-view");return Object(c["t"])(),Object(c["g"])("div",{class:Object(c["p"])(["app",{"timeline-tab":"/timeline"===e.$route.fullPath}])},[Object(c["j"])(s,{isTimeline:"/timeline"===e.$route.fullPath},null,8,["isTimeline"]),Object(c["j"])(o)],2)}var a=function(e){return Object(c["w"])("data-v-556cf541"),e=e(),Object(c["u"])(),e},r={class:"main-navbar"},s={class:"container"},o=a((function(){return Object(c["h"])("div",{class:"nav-wrapper"},[Object(c["h"])("a",{href:"#",class:"brand-logo center"},"Новости Камчатки"),Object(c["h"])("a",{href:"#","data-target":"mobile-demo",class:"sidenav-trigger"},[Object(c["h"])("i",{class:"material-icons sidenav-overlay"},"menu")])],-1)})),u={class:"nav-content"},l={class:"tabs tabs-transparent"},d={class:"tab"},b=Object(c["i"])("Лента"),m={class:"tab"},f=Object(c["i"])("Таймлайн"),p={class:"tab"},h=Object(c["i"])("Предложить пост");function j(e,t,n,i,a,j){var O=Object(c["A"])("my-sidebar"),v=Object(c["A"])("router-link");return Object(c["t"])(),Object(c["g"])("div",r,[Object(c["h"])("span",{onClick:t[0]||(t[0]=function(e){return a.isSidebar=!a.isSidebar}),class:"material-icons my-menu"}," menu "),Object(c["j"])(c["b"],null,{default:Object(c["G"])((function(){return[a.isSidebar?(Object(c["t"])(),Object(c["e"])(O,{key:0})):Object(c["f"])("",!0)]})),_:1}),Object(c["h"])("nav",{class:Object(c["p"])(["nav-extended",{"nav-timeline":n.isTimeline}])},[Object(c["h"])("div",s,[o,Object(c["h"])("div",u,[Object(c["h"])("ul",l,[Object(c["h"])("li",d,[Object(c["j"])(v,{to:"/"},{default:Object(c["G"])((function(){return[b]})),_:1})]),Object(c["h"])("li",m,[Object(c["j"])(v,{to:"/timeline"},{default:Object(c["G"])((function(){return[f]})),_:1})]),Object(c["h"])("li",p,[Object(c["j"])(v,{to:"/newPost"},{default:Object(c["G"])((function(){return[h]})),_:1})])])])])],2)])}var O=function(e){return Object(c["w"])("data-v-70706264"),e=e(),Object(c["u"])(),e},v={class:"my-sidebar"},g=O((function(){return Object(c["h"])("h6",null,"Настроить ленту",-1)})),y={class:"collapsible"},w=O((function(){return Object(c["h"])("li",null,[Object(c["h"])("div",{class:"collapsible-header"},[Object(c["h"])("i",{class:"material-icons"},"sync"),Object(c["i"])(" Свежее ")])],-1)})),k=O((function(){return Object(c["h"])("li",null,[Object(c["h"])("div",{class:"collapsible-header"},[Object(c["h"])("i",{class:"material-icons"},"whatshot"),Object(c["i"])(" Популярные ")])],-1)})),T=O((function(){return Object(c["h"])("div",{class:"collapsible-header"},[Object(c["h"])("i",{class:"material-icons"},"event"),Object(c["i"])(" По дате ")],-1)})),_={class:"collapsible-body"},x={class:"inputs-block"},C=O((function(){return Object(c["h"])("p",{class:"equal-size date-p"},":",-1)}));function E(e,t,n,i,a,r){return Object(c["t"])(),Object(c["g"])("div",v,[g,Object(c["h"])("ul",y,[w,k,Object(c["h"])("li",null,[T,Object(c["h"])("div",_,[Object(c["h"])("div",x,[Object(c["H"])(Object(c["h"])("input",{"onUpdate:modelValue":t[0]||(t[0]=function(t){return e.stateDate=t}),class:"equal-size",type:"text",placeholder:"с"},null,512),[[c["E"],e.stateDate]]),C,Object(c["H"])(Object(c["h"])("input",{"onUpdate:modelValue":t[1]||(t[1]=function(e){return a.endDate=e}),class:"equal-size",type:"text",placeholder:"по"},null,512),[[c["E"],a.endDate]])])])])])])}var L=n("4d5c"),P=n.n(L),A={mounted:function(){P.a.AutoInit()},data:function(){return{startDate:"",endDate:""}}},D=(n("99b1"),n("6b0d")),S=n.n(D);const $=S()(A,[["render",E],["__scopeId","data-v-70706264"]]);var N=$,F={props:{isTimeline:{type:Boolean}},components:{mySidebar:N},data:function(){return{isSidebar:!1}}};n("d1bb"),n("0716");const I=S()(F,[["render",j],["__scopeId","data-v-556cf541"]]);var V=I,q={components:{mainNavbar:V}};n("8bbc");const z=S()(q,[["render",i]]);var M=z,B=(n("d3b7"),n("3ca3"),n("ddb0"),n("6c02")),G=function(e){return Object(c["w"])("data-v-efee24d4"),e=e(),Object(c["u"])(),e},H={class:"home-page"},R=G((function(){return Object(c["h"])("h1",null,"Новостной портал по Камчатке",-1)})),U={class:"container-timeline"};function J(e,t,n,i,a,r){var s=Object(c["A"])("timeline-map"),o=Object(c["A"])("news-card");return Object(c["t"])(),Object(c["g"])("div",H,[R,a.timeline?(Object(c["t"])(),Object(c["e"])(s,{key:0})):Object(c["f"])("",!0),Object(c["h"])("div",U,[(Object(c["t"])(!0),Object(c["g"])(c["a"],null,Object(c["z"])(e.$store.state.contents,(function(e){return Object(c["t"])(),Object(c["e"])(o,{onClick:function(t){return r.openCardNews(e)},key:e,cardContent:e},null,8,["onClick","cardContent"])})),128))])])}var K={class:"card"},W={class:"withPadding"},Q={class:"card-title"},X={class:"description"},Y={class:"img-block"},Z=["src"],ee={class:"like"},te={class:"useless"};function ne(e,t,n,i,a,r){return Object(c["t"])(),Object(c["g"])("div",K,[Object(c["h"])("div",W,[Object(c["h"])("div",Q,[Object(c["h"])("h5",null,Object(c["C"])(n.cardContent.title),1)]),Object(c["h"])("div",X,[Object(c["h"])("p",null,Object(c["C"])(n.cardContent.text),1)])]),Object(c["h"])("div",Y,[Object(c["h"])("img",{src:n.cardContent.pictureLink,alt:""},null,8,Z)]),Object(c["h"])("div",{onClick:t[2]||(t[2]=Object(c["I"])((function(){}),["stop"])),class:"reaction withPadding"},[Object(c["h"])("p",ee,Object(c["C"])(a.like),1),Object(c["h"])("span",{onClick:t[0]||(t[0]=function(e){return a.like++}),class:"material-icons"}," expand_less "),Object(c["h"])("span",{onClick:t[1]||(t[1]=function(e){return a.useless++}),class:"material-icons"}," expand_more "),Object(c["h"])("p",te,Object(c["C"])(a.useless),1)])])}var ce={props:{cardContent:{type:Object}},data:function(){return{like:10,useless:3}}};n("025a");const ie=S()(ce,[["render",ne],["__scopeId","data-v-4c36f701"]]);var ae=ie,re=function(e){return Object(c["w"])("data-v-a971178a"),e=e(),Object(c["u"])(),e},se={class:"block-on-click"},oe={class:"row timeline_map"},ue={class:"col m6 timeline-scroll"},le={class:"timeline"},de={class:"container"},be={class:"timeline"},me=re((function(){return Object(c["h"])("div",{class:"col m6 col-for-map"},[Object(c["h"])("div",{class:"map"},[Object(c["h"])("div",{class:"point point-west"}),Object(c["h"])("div",{class:"point point-east"})])],-1)}));function fe(e,t,n,i,a,r){var s=Object(c["A"])("timeline-event");return Object(c["t"])(),Object(c["g"])("div",se,[Object(c["h"])("div",oe,[Object(c["h"])("div",ue,[Object(c["h"])("div",le,[Object(c["h"])("div",de,[Object(c["h"])("div",be,[(Object(c["t"])(!0),Object(c["g"])(c["a"],null,Object(c["z"])(e.$store.state.dataForTimeline,(function(e){return Object(c["t"])(),Object(c["e"])(s,{key:e,content:e},null,8,["content"])})),128))])])])]),me])])}var pe=n("32ad"),he={components:{timelineEvent:pe["a"]},methods:{fetchWest:function(){this.$store.commit("clearTimeline"),this.$store.commit("forTest_west")},fetchEast:function(){this.$store.commit("clearTimeline"),this.$store.commit("forTest_east")}}};n("3fbd");const je=S()(he,[["render",fe],["__scopeId","data-v-a971178a"]]);var Oe=je,ve={components:{newsCard:ae,timelineMap:Oe},mounted:function(){this.$store.dispatch("fetchLineNews"),console.log(this.$store.state.contents)},data:function(){return{timeline:!1}},methods:{openCardNews:function(e){this.$router.push("/news/".concat(e.title))},showTimeLine:function(){this.$store.dispatch("fetchTimelineData"),this.timeline=!0},clearTimeline:function(){this.$store.commit("clearTimeline")},hiddenTimeline:function(){this.timeline=!1}}};n("e4b1");const ge=S()(ve,[["render",J],["__scopeId","data-v-efee24d4"]]);var ye=ge,we=[{path:"/",name:"Home",component:ye},{path:"/news/:id",component:function(){return n.e("chunk-e64e3e10").then(n.bind(null,"2d04"))}},{path:"/timeline",component:function(){return n.e("chunk-8b2b73cc").then(n.bind(null,"5bf8"))}},{path:"/newPost",component:function(){return n.e("chunk-f791cfb4").then(n.bind(null,"6e73"))}}],ke=Object(B["a"])({history:Object(B["b"])("/"),routes:we}),Te=ke,_e=n("1da1"),xe=(n("96cf"),n("159b"),n("5502")),Ce=Object(xe["a"])({state:{dataForTimeline:[],contents:[{title:"Камчатка новости",text:"Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",img:n("7706"),year:2019},{title:"Камчатка новости 1",text:"Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",img:n("7706"),year:2019},{title:"Камчатка новости 2",text:"Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",img:n("7706"),year:2019},{title:"Камчатка новости 3",text:"Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",img:n("7706"),year:2019},{title:"Камчатка новости 4",text:"Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",img:n("7706"),year:2019},{title:"Камчатка новости 5",text:"Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",img:n("7706"),year:2019},{title:"Камчатка новости 6",text:"Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",img:n("7706"),year:2019}]},mutations:{clearTimeline:function(e){e.dataForTimeline=[]},forTest_west:function(e){for(var t=0;t<3;t++)e.dataForTimeline.push(e.contents[t])},forTest_east:function(e){for(var t=3;t<e.contents.length;t++)e.dataForTimeline.push(e.contents[t])},setDataForTimeline:function(e,t){e.dataForTimeline=t},setDataForLineNews:function(e,t){e.contents.push(t)}},actions:{fetchTimelineData:function(e){return Object(_e["a"])(regeneratorRuntime.mark((function t(){var n,c;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.next=2,fetch("/api/EcologyEvents");case 2:return n=t.sent,t.next=5,n.json();case 5:c=t.sent,e.commit("setDataForTimeline",c);case 7:case"end":return t.stop()}}),t)})))()},fetchLineNews:function(e){return Object(_e["a"])(regeneratorRuntime.mark((function t(){var n,c;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.next=2,fetch("/api/EcologyEvents");case 2:return n=t.sent,t.next=5,n.json();case 5:c=t.sent,c.forEach((function(t){return e.commit("setDataForLineNews",t)}));case 7:case"end":return t.stop()}}),t)})))()}},modules:{}});Object(c["d"])(M).use(Ce).use(Te).mount("#app")},7706:function(e,t,n){e.exports=n.p+"img/testPicture.bfcdf189.jpg"},"783f":function(e,t,n){},8191:function(e,t,n){},"8bbc":function(e,t,n){"use strict";n("c98a")},"99b1":function(e,t,n){"use strict";n("783f")},a8ae:function(e,t,n){},c98a:function(e,t,n){},d1bb:function(e,t,n){"use strict";n("d515")},d515:function(e,t,n){},e4b1:function(e,t,n){"use strict";n("a8ae")},eda8:function(e,t,n){},f065:function(e,t,n){}});
//# sourceMappingURL=app.c0afd17b.js.map