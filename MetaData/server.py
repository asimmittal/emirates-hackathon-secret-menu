import json
from flask import Flask
app = Flask(__name__)

breadcrumbs = None
friends = None

@app.route("/friends")
def getFriends():
	return friends

@app.route("/crumbs")
def getCrumbs():
	return breadcrumbs


if __name__ == '__main__':

	filename_friends = "friends.json"
	filename_crumbs = "breadcrumbs.json"
	friends = open(filename_friends).read()
	breadcrumbs = open(filename_crumbs).read()

	app.run(host='0.0.0.0',port=5001)