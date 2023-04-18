pipeline {
    agent any

    stages {
        stage('Hello') {
            steps {
                git branch: 'main', url: 'https://github.com/BossBunch/UI.MvcApplication.git'
            }
        }
        stage('Build') {
    					steps {
    					    bat "\"${tool 'MSBuild'}\" MVC.sln   /t:restore  /p:outdir=Publish  /p:Configuration=Debug /p:Platform=\"Any CPU\" "
    					    //powershell 'MsBuild MVC.sln   /t:restore /t:build /p:Configuration=Debug /p:Platform="Any CPU"'
    					    
    					}
				}
    }
}
