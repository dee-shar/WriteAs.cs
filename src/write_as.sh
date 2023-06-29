#!/bin/bash

api="https://write.as/api/"
user_agent="Write.as v1.7.0; Android"

function publish_text()  {
	# 1 - word: (string): <words>
	curl --request POST \
		--url "$api" \
		--user-agent "$user_agent" \
		--header "content-type: application/x-www-form-urlencoded" \
		--data "w=$1&font=norm&lang=en&rtl=false"
}
