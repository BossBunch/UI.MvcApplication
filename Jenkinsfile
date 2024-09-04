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
    					    bat "\"${tool 'MSBuild'}\" dotnet restore MVC/MVC.csproj"  					    
    					}
				}
    }
}
