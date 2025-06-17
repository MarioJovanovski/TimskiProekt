import React from 'react'; 
import { useNavigate } from 'react-router-dom';

const LoginPage: React.FC = () => {
    const navigate = useNavigate()

    const navigateToHomeScreen = () => {
        navigate("/home")
    }
    return (
    <>
        <div className="min-h-screen bg-gradient-to-br from-gray-900 to-black flex items-center justify-center p-4">
        
            <div className="bg-gray-800 p-10 rounded-3xl shadow-2xl w-full max-w-md transform transition-all duration-300 hover:scale-105 border border-gray-700">
            
            <h1 className="text-4xl font-extrabold text-white mb-8 text-center tracking-wide">
                HR App Login
            </h1>
            
            <form className="space-y-6">
            
                <div className="mb-4">
                <label className="block text-sm font-medium text-gray-300 mb-2" htmlFor="email">
                    Email
                </label>
                <input
                    id="email"
                    type="email"
                    placeholder="Enter your email"
                    className="w-full px-5 py-3 rounded-xl bg-gray-700 text-white border border-gray-600 placeholder-gray-400 focus:outline-none focus:ring-3 focus:ring-blue-500 focus:border-blue-500 transition duration-300"
                
                />
                </div>

                <div className="mb-6">
                <label className="block text-sm font-medium text-gray-300 mb-2" htmlFor="password">
                    Password
                </label>
                <input
                    id="password"
                    type="password"
                    placeholder="Enter your password"
                    className="w-full px-5 py-3 rounded-xl bg-gray-700 text-white border border-gray-600 placeholder-gray-400 focus:outline-none focus:ring-3 focus:ring-blue-500 focus:border-blue-500 transition duration-300"

                />
                </div>

                <button
                type="submit"
                className="w-full bg-blue-600 hover:bg-blue-700 active:bg-blue-800 text-white font-bold text-lg py-3 px-4 rounded-xl transition duration-300 transform hover:-translate-y-1 shadow-lg focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
                onClick={navigateToHomeScreen}
                >
                Log In
                </button>
            </form>

            
            <div className="mt-8 text-center text-sm">
                <a href="#" className="text-blue-400 hover:text-blue-300 font-medium transition duration-300">
                Forgot password?
                </a>
                <span className="mx-2 text-gray-500">|</span>
                <a href="#" className="text-blue-400 hover:text-blue-300 font-medium transition duration-300">
                Don't have an account? Sign up
                </a>
            </div>
            </div>

        
            <footer className="absolute bottom-4 text-gray-500 text-sm">
            &copy; {new Date().getFullYear()} Your Company Name. All rights reserved.
            </footer>
        </div>
    </>
  );
}

export default LoginPage;