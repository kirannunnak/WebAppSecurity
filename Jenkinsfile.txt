pipeline {
            agent any
            
             environment {
                            IMAGE_NAME = "gymoneapp"       // Docker image name
                            IMAGE_TAG = "latest"               // Image tag (could also use branch name or commit ID)
                            DOCKERHUB_REPO = "kirannunna2024/gymoneapp" // Docker Hub repo (replace with your Docker Hub username/repo)
            }
    
            stages {
                stage('CheckOut Code') {
                steps{
                          script {
                                    withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'Gitcredentials', usernameVariable: 'Username', passwordVariable: 'Password']]) 
                                    {
                                        sh "git clone https://$GIT_USERNAME:$GIT_PASSWORD@https://github.com/kirannunnak/GYMONE.git"
                                    }  
                                }
                        }
                    }
            }
    }
