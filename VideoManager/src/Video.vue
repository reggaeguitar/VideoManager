<template>
  <div>
    <div class="container">
      <div class="col-md-4" v-for='video in videos'>
        <label>Title:</label>{{ video.Title }}<br />
        <div class="linklike"
             v-on:click="openInNewTabAndIncrementVisitCount(video)">
          {{ video.Url }}
        </div><br />
        <label>Points:</label>{{ video.Points }}<br />
        <label>Visit count:</label>{{ video.VisitCount }}<br />
        <label>Date added:</label>{{ video.DateAdded }}<br />
        <label>Last visited:</label>{{ video.LastVisited }}<br />
        <h4 class="te">Actors</h4>
        <div>
          <div v-for='actor in video.Actors'>
            <span class="badge">{{ actor }}</span>
          </div>
        </div>
        <h4>Tags</h4>
        <div>
          <div v-for='tag in video.Tags'>
            <p>{{ tag }}</p>
          </div>
        </div>
        <button v-on:click="deleteVideo(video)">Delete</button>
        <hr />
      </div>
    </div>
  </div>
</template>
<script>
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.css';

const serviceUrl = 'http://localhost:13672/api/';

export default {
  name: 'app',
  data: () => ({
    videos: [{ Url: 'test' }],

    loadVideos: function() {
      axios.get(serviceUrl + 'videos')
      .then(response => {
        this.videos = response.data
      })
      .catch(e => {
        console.log(e);
      });
    }
  }),

  created() {
    this.loadVideos();
  },

  methods: {
    openInNewTabAndIncrementVisitCount: function(video) {
      this.videos = undefined;
      var videoId = video.VideoId;
      axios.get(serviceUrl + 'increment/' + videoId);
      this.loadVideos();
      window.open(video.Url, '_blank');
    },
    deleteVideo: function(video) {
      var videoId = video.VideoId;
      axios.get(serviceUrl + 'delete/' + videoId);
      this.loadVideos();
    }
  }
}
</script>
<style> 
  .linklike {
    cursor:pointer;
    color:blue;
    text-decoration:underline;
  }
</style>