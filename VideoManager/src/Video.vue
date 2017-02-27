<template>
<ol>
	<li v-for='video in videos'>
		<label>Title:</label>{{ video.Title }}<br />
		<a :href='video.Url'>{{ video.Url }}</a><br />
		<label>Points:</label>{{ video.Points }}<br />
		<label>Visit count:</label>{{ video.VisitCount }}<br />
		<label>Date added:</label>{{ video.DateAdded }}<br />
		<label>Last visited:</label>{{ video.LastVisited }}<br />               
		<h4>Actors</h4>
		<ol>
			<li v-for='actor in video.Actors'>
				<p>{{ actor }}</p>
			</li>
		</ol>
		<h4>Tags</h4>
		<ol>
			<li v-for='tag in video.Tags'>
				<p>{{ tag }}</p>
			</li>
		</ol>
	</li>
</ol>
</template>
<script>
import axios from 'axios';

export default {
  name: 'app',
  data: () => ({
	videos: [{ Url: 'test' }]
  }),

  created() {
    axios.get('http://localhost:13672/api/videos')
    .then(response => {
      // JSON responses are automatically parsed.
	  console.log(response)
      this.videos = response.data
    })
    .catch(e => {
      console.log(e);
      //this.errors.push(e)
    })
  }
}
</script>