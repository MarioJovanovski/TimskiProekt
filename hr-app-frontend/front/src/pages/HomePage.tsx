function HomePage() {
  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-600 to-white-700 flex flex-col items-center justify-center p-4">
      {/* Main container for the home page content */}
      <div className="bg-white p-8 rounded-2xl shadow-xl text-center max-w-lg w-full transform transition-all duration-300 hover:scale-105">
        {/* Page Title */}
        <h1 className="text-5xl font-extrabold text-gray-800 mb-6 tracking-tight">
          Welcome to Our App!
        </h1>

        {/* Introductory Paragraph */}
        <p className="text-lg text-gray-600 mb-8 leading-relaxed">
          This is your starting point for an amazing experience. Explore, engage, and discover what we have to offer.
        </p>

        {/* Call to Action Button */}
        <button
          className="bg-red-600 text-white px-8 py-3 rounded-full text-lg font-semibold shadow-lg hover:bg-purple-700 transition-colors duration-300 transform hover:-translate-y-1"
          onClick={() => alert('Explore button clicked!')} // Placeholder for future navigation
        >
          Explore Now
        </button>
      </div>

      {/* Footer text for branding or additional info */}
      <footer className="mt-12 text-white text-md opacity-80">
        &copy; {new Date().getFullYear()} Your Company Name. All rights reserved.
      </footer>
    </div>
  );
}

export default HomePage;