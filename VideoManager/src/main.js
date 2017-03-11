import Vue from 'vue';
import Video from './Video.vue';

import 'jquery';
import 'bootstrap/dist/css/bootstrap.css';

new Vue({
    el: '#app',
    render: h => h(Video)
});
