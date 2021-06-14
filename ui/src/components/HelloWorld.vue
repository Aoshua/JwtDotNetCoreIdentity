<template>
	<div class="hello">
		<div class="row" style="margin: 1rem;">
			<div class="col-3" style="word-wrap: break-word">
				<h5>Test Login</h5>
				<input type="text" class="form-control mb-2" v-model="email" />
				<input type="text" class="form-control mb-2" v-model="password" />
				<button type="button" class="btn btn-success mb-2" @click="logIn">Login</button>
				<p>Token: {{ token }}</p>
			</div>
			<div class="col-3">
				<h5>Test Authorization</h5>
				<button type="button" class="btn btn-primary mb-2" :disabled="disabled" @click="testAuthorize">Test</button>
				<p>Status: {{ authStatus }}</p>
			</div>
			<div class="col-3">
				<h5>Test Visitor Role</h5>
				<button type="button" class="btn btn-warning mb-2" :disabled="disabled" @click="testVisitor">Test</button>
				<p>Status: {{ visitorStatus }}</p>
			</div>
			<div class="col-3">
				<h5>Test Admin Role</h5>
				<button type="button" class="btn btn-danger mb-2" :disabled="disabled" @click="testAdmin">Test</button>
				<p>Status: {{ adminStatus }}</p>
			</div>
		</div>
	</div>
</template>

<script>
	import axios from "axios"

	export default {
		name: "HelloWorld",
		data() {
			return {
				baseUrl: "https://localhost:44301/",
				email: "joshsTestEmail@gmail.com",
				password: "myPass111",
				token: "NA",
				authHeader: {},
				authStatus: "NA",
				visitorStatus: "NA",
				adminStatus: "NA",
				disabled: false
			}
		},
		methods: {
			async logIn() {
				let r = await axios.post(this.baseUrl + "api/account/login", { Email: this.email, Password: this.password })
				this.token = r.data

				this.authHeader = {
					headers: {
						Authorization: `Bearer ${this.token}`
					}
				}

				this.disabled = false
			},
			testAuthorize() {
				axios.get(this.baseUrl + "api/test/testauthorize", this.authHeader)
				.then(r => {
					this.authStatus = r.data
				}).catch(e => {
					this.authStatus = e
				})
			},
			testVisitor() {
				axios.get(this.baseUrl + "api/test/testrole", this.authHeader)
				.then(r => {
					this.visitorStatus = r.data
				}).catch(e => {
					this.visitorStatus = e
				})
			},
			testAdmin() {
				axios.get(this.baseUrl + "api/test/testroleparttwo", this.authHeader)
				.then(r => {
					this.adminStatus = r.data
				}).catch(e => {
					this.adminStatus = e
				})
			}
		},
	}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
	h3 {
		margin: 40px 0 0;
	}
	ul {
		list-style-type: none;
		padding: 0;
	}
	li {
		display: inline-block;
		margin: 0 10px;
	}
	a {
		color: #42b983;
	}
</style>
