#!/bin/bash

sudo apt update
sudo apt upgrade -y curl git zsh

sh -c "$(curl -fsSL https://raw.github.com/ohmyzsh/ohmyzsh/master/tools/install.sh)"