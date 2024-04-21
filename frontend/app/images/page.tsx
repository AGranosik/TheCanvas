"use client";

import { useModelContext } from "@/context/useModelContext";
import { ReferencedLinks } from "@/lib/links";
import {
  ReactCompareSlider,
  ReactCompareSliderImage,
} from "react-compare-slider";

export default function Home() {
  const model = useModelContext();

  const links = ReferencedLinks[model || ""];

  if (!links?.image) {
    return null;
  }

  return (
    <div className="grid h-screen w-full pl-[53px]">
      <ReactCompareSlider
        itemOne={
          <ReactCompareSliderImage src={links.image.now} alt="Image one" />
        }
        itemTwo={
          <ReactCompareSliderImage src={links.image.then} alt="Image two" />
        }
      />
    </div>
  );
}
