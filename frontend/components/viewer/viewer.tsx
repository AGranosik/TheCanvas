import { useRef, useEffect } from "react";
import Image from "next/image";
import { Viewer, DefaultViewerParams, SpeckleLoader } from "@speckle/viewer";
import { CameraController } from "@speckle/viewer";

// Define an interface for the component props
interface ViewerCompProps {
  url: string; // Specify that 'url' is a required string
}

// Use the interface to type the function component's props
export default function ViewerComp({ url }: ViewerCompProps) {
  // Create a ref for the container div
  const containerRef = useRef(null);
  /** Configure the viewer params */
  const params = DefaultViewerParams;

  useEffect(() => {
    async function main() {
      if (containerRef.current) {
        try {
          /** Get the HTML container via ref */
          const container = containerRef.current;

          // Clear the container before appending new elements
          //@ts-ignore
          while (container.firstChild) {
            //@ts-ignore
            container.removeChild(container.firstChild);
          }
          /** Create Viewer instance */
          const viewer = new Viewer(container, params);

          /** Initialise the viewer */
          await viewer.init();

          /** Add the stock camera controller extension */
          viewer.createExtension(CameraController);

          /** Create a loader for the speckle stream */
          const loader = new SpeckleLoader(
            viewer.getWorldTree(),
            url,
            "9e873734857c1570aa623e5ab7905292293fc82976"
          );
          /** Load the speckle data */
          await viewer.loadObject(loader, true);
        } catch (error) {
          console.error("Error loading the viewer", error);
        }
      } else {
        console.log("Container not found");
      }
    }

    // Call our function, which we named 'main'
    main();
  }, [url]); // Empty dependency array to run only once after the initial render

  return (
    <div
    className="flex w-full h-full min-h-screen justify-center items-center"
    ref={containerRef}
    style={{ width: "100%", height: "100%" }}
  ></div>
  );
}
