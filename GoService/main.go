package main

import (
	"encoding/json"
	"net/http"
)

// to build: 'go build' (creates RunicMagic.exe)

func main() {
	http.HandleFunc("/spell", handleSpellParse)
	http.ListenAndServe(":10000", nil)
}

type parseResponse struct {
	Spell string `json:"spell"`
}

func handleSpellParse(w http.ResponseWriter, req *http.Request) {
	resp := parseResponse{Spell: "test"}
	b, err := json.Marshal(resp)
	if err != nil {
		w.WriteHeader(http.StatusInternalServerError)
		return
	}
	w.Write(b)
}
